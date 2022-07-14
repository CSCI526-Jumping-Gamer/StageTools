using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PVCManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    
    [SerializeField] float targetDistance = 10f;
    [SerializeField] Vector3 targetOffset = new Vector3(0f, 0f, 0f);
    [SerializeField] float cameraSpeed = 0.1f;
    // [SerializeField] bool isZoomActivated = true;
    [SerializeField] bool isTriggered = false;
    

    float currentDistance;
    Vector3 currentOffset;
    CinemachineTransposer vcamTransposer;

    void Start() {
        currentDistance = virtualCamera.m_Lens.OrthographicSize;
        vcamTransposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        currentOffset = vcamTransposer.m_FollowOffset;
    }
   

    private void LateUpdate() {
        if (isTriggered) {
            ZoomCamera();
            AddOffset();
        }
        else {
            RevertZoomCamera();
            RevertOffset();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = true;
            // Debug.Log("Zoom In");
            // virtualCamera.m_Lens.OrthographicSize -= distance;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = false;
            // virtualCamera.m_Lens.OrthographicSize += distance;
            // Debug.Log("Zoom Out");
        }
    }
    
    private void ZoomCamera() {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize,targetDistance,cameraSpeed);
    }

    private void RevertZoomCamera() {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize,currentDistance,cameraSpeed);
    }

    private void AddOffset() {
        vcamTransposer.m_FollowOffset = Vector3.Lerp(vcamTransposer.m_FollowOffset, targetOffset, cameraSpeed);
    }

    private void RevertOffset() {
        vcamTransposer.m_FollowOffset = Vector3.Lerp(vcamTransposer.m_FollowOffset, currentOffset, cameraSpeed);
    }
}
