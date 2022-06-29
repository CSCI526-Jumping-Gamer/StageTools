using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    CardTimer cardTimer;
    public PlayerController playerController;
    [SerializeField] private float defDistanceRay = 50;
    [SerializeField] float loadDelay = 0.2f;
    DeltaDnaEventHandler deltaDnaEventHandler;

    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    //   public GameManager gameManager;
    //   public Shield shield;
    private float count; // Invincible time
    // private float invisible_time;
    private bool flag;
    Transform m_transform;
    RaycastHit2D _hit;
    Rigidbody2D otherRb2d;


    private void Awake()
    {
        cardTimer = FindObjectOfType<CardTimer>();
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();

        playerController = FindObjectOfType<PlayerController>();
        count = 0;
        // invisible_time = 1;
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
            _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            if (_hit.transform.tag.ToString() == "Player")
            {
                otherRb2d = _hit.collider.gameObject.GetComponent<Rigidbody2D>();

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
                    string propName = gameObject.name;
                    int propID = gameObject.GetInstanceID();
                    // Debug.Log(propName + '/' + propID);
                    // deltaDnaEventHandler.RecordPlayerDied(otherRb2d.transform.position, propName, propID);
                    Invoke("Respawning", loadDelay);
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

    // void ReloadScene()
    // {
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentSceneIndex);
    // }

    void Respawning()
    {
        // Debug.Log(playerController);
        otherRb2d.transform.position = playerController.GetCheckPointPosition();
        playerController.EnablePlayerInput();
    }
}