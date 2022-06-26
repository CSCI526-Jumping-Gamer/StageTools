using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    GameObject scoreboard;
    GameObject cardTimer;
    PlayerController playerController;


    // Start is called before the first frame update
    private void Awake()
    {
        scoreboard = GameObject.FindWithTag("Scoreboard");
        cardTimer = GameObject.FindWithTag("CardTimer");
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            scoreboard.transform.Find("Wrapper").gameObject.SetActive(true);
            cardTimer.transform.Find("Wrapper").gameObject.SetActive(false);
            playerController.DisablePlayerInput();
            FindObjectOfType<StarColor>().setStarColor(); // set the star color 
            TimeControl.instance.TimerEnd(); // end the timer;
            TimeControl.instance.showTimerOnEndCanvas();
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
