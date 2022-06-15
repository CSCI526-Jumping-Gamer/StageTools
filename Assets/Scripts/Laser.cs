using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 10;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    public GameManager gameManager;
    Transform m_transform;

    private void Awake()
    {
     //   print("awake");
        m_transform = GetComponent<Transform>();
    }

    public void Update()
    {
     //   print("laser " + laserFirePoint);
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            
            //print("laser hit: " + _hit.transform.ToString() + "boolean: " + _hit.transform.ToString() == "Player");
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            if (_hit.transform.ToString() == "Player (UnityEngine.Transform)")
            {
                gameManager.EndGame();
                print("true");
            }
            print("laser hit: " + "a" +  _hit.transform.ToString() + "a");
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
        
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

}