using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PVCManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    
    [SerializeField] float distance = 10f;
    
    
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            virtualCamera.m_Lens.OrthographicSize -= distance;
            Debug.Log("Zoom In");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            virtualCamera.m_Lens.OrthographicSize += distance;
            Debug.Log("Zoom Out");
        }
        
    }
}
