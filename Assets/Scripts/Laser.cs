using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 50;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
 //   public GameManager gameManager;
 //   public Shield shield;
    private float count; // Invincible time
    // private float invisible_time;
    private bool flag;
    Transform m_transform;

    private void Awake()
    {
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
        if (Physics2D.Raycast(m_transform.position, transform.right) )
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Debug.Log(_hit.transform.tag.ToString());
            if (_hit.transform.tag.ToString() == "Player")
            {
                Invoke("ReloadScene", 0);
            }
            Physics2D.IgnoreLayerCollision(5,2,true);
        /*    if (_hit.transform.tag.ToString() == "Magnet")
            {
                
                float x = laserFirePoint.transform.right.x;
                float y = laserFirePoint.transform.right.y;
                _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
                Vector2 endPos = new Vector2(laserFirePoint.position.x + x * defDistanceRay, laserFirePoint.position.y + y * defDistanceRay);
                Draw2DRay(laserFirePoint.position, _hit.point);
            }*/
         //   else
           // {
             Draw2DRay(laserFirePoint.position, _hit.point);
         //   }
        }
        else
        {
            //      Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
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

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}