using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] int sceneNumber = 0;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] GameObject endScene;
    

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            finishEffect.Play();
            // Ian added
            endScene.SetActive(true); // activate end scene
            FindObjectOfType<StarColor>().setStarColor(); // set the star color 
            TimeControl.timerObj.TimerEnd(); // end the timer;
            TimeControl.timerObj.showTimerOnEndCanvas();
            //Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(sceneNumber);
    }
}
