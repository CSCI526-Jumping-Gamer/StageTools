using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.Services.Analytics
{
    public class RespawnPlayer : MonoBehaviour
    {
        CardTimer cardTimer;
        PlayerController playerController;
        Collider2D playerCollider;
        AnalyticsEventHandler analyticsEventHandler;
        GameAnalyticsEventHandler gameAnalyticsEventHandler;
        DeltaDnaEventHandler deltaDnaEventHandler;
        // Teleporter teleporter;
        [SerializeField] float loadDelay = 0.2f;

        void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
            cardTimer = FindObjectOfType<CardTimer>();
            deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
            // analyticsEventHandler = FindObjectOfType<AnalyticsEventHandler>();
            // gameAnalyticsEventHandler = FindObjectOfType<GameAnalyticsEventHandler>();
            // GameAnalytics.Initialize();
            // teleporter = FindObjectOfType<Teleporter>();
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (tag == "DeathZone")
            {
                if (PlayerController.instance.isUsingCard)
                {
                    cardTimer.Deactivate();
                }
            }

            if (other.tag == "Player")
            {
                playerCollider = other;

                if (PlayerController.instance.shieldCount > 0)
                {
                    // analyticsEventHandler.RecordShieldUsed(other.transform.position);
                    PlayerController.instance.shieldCount -= 1;

                    if (PlayerController.instance.shieldCount == 0)
                    {
                        cardTimer.Deactivate();
                    }
                }
                else
                {
                    // analyticsEventHandler.RecordPlayerDeath(other.transform.position);
                    // gameAnalyticsEventHandler.RecordPlayerDied(other.transform.position);
                    string trapName = gameObject.name;
                    int trapId = gameObject.GetInstanceID();
                    playerController.DisablePlayerInput();

                    if (deltaDnaEventHandler)
                    {
                        deltaDnaEventHandler.RecordPlayerDied(other.transform.position, trapName, trapId);
                    }

                    Invoke("Respawn", loadDelay);
                }
            }
        }

        public void Respawn()
        {
            // Rigidbody2D otherRb2d = playerCollider.gameObject.GetComponent<Rigidbody2D>();
            // otherRb2d.transform.position = playerController.GetCheckPointPosition();
            playerController.transform.position = playerController.GetCheckPointPosition();
            playerController.EnablePlayerInput();
        }
    }
}
