using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChild : MonoBehaviour
{
    public bool isTriggered = false;
    public bool keepActivated = false;
    // // Start is called before the first frame update
    void Start()
    {
        // transform.GetChild(0).gameObject.SetActive(false);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other.tag);
        if ((other.tag == "Player") || (other.tag == "Feet")) { 
            transform.GetChild(0).gameObject.SetActive(true);
            isTriggered = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {  
        if ((other.tag == "Player") || (other.tag == "Feet")) { 
            if (!keepActivated) {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            isTriggered = false;
        }
    }
}
