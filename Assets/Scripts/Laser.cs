using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    CardTimer cardTimer;
    PlayerController playerController;
    DeltaDnaEventHandler deltaDnaEventHandler;
    float count; // Invincible time
    bool flag;
    Transform m_transform;
    bool isDead = false;

    [SerializeField] float defDistanceRay = 50;
    [SerializeField] float loadDelay = 0.2f;

    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    
    private void Awake()
    {
        cardTimer = FindObjectOfType<CardTimer>();
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
        playerController = FindObjectOfType<PlayerController>();
        count = 0;
        flag = false;
        m_transform = GetComponent<Transform>();
    }

    public void Update()
    {
        if (flag)
        {
            count += Time.deltaTime;
        }
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            // Debug.Log(_hit.transform.tag);
            if (_hit.collider.transform.tag == "Player")
            {
                if (!isDead) {
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
                        playerController.DisablePlayerInput();
                        string trapName = gameObject.name;
                        int trapId = gameObject.GetInstanceID();

                        if (deltaDnaEventHandler) {
                            deltaDnaEventHandler.RecordPlayerDied(playerController.transform.position, trapName, trapId);
                        }
                        
                        isDead = true;
                        Invoke("Respawning", loadDelay);
                    }
                }
            }
            // Physics2D.IgnoreLayerCollision(5,2,true);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            float x = laserFirePoint.transform.right.x;
            float y = laserFirePoint.transform.right.y;

            Vector2 endPos = new Vector2(laserFirePoint.position.x + x * defDistanceRay, laserFirePoint.position.y + y * defDistanceRay);
            Draw2DRay(laserFirePoint.position, endPos);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    void Respawn()
    {
        isDead = false;
        // otherRb2d.transform.position = playerController.GetCheckPointPosition();
        playerController.transform.position = playerController.GetCheckPointPosition();
        playerController.EnablePlayerInput();
    }
}