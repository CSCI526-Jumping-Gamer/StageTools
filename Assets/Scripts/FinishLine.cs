using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    GameObject scoreboard;
    PlayerController playerController;


    // Start is called before the first frame update
    private void Awake()
    {
        scoreboard = GameObject.FindWithTag("Scoreboard");
        playerController = FindObjectOfType<PlayerController>();
    }

    // private void Start()
    // {
    //     scoreboard.SetActive(false);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            // Ian added
            scoreboard.transform.Find("Wrapper").gameObject.SetActive(true);
            scoreboard.SetActive(true); // activate end scene
            playerController.DisablePlayerInput();
            FindObjectOfType<StarColor>().setStarColor(); // set the star color 
            TimeControl.timerObj.TimerEnd(); // end the timer;
            TimeControl.timerObj.showTimerOnEndCanvas();
            //Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
