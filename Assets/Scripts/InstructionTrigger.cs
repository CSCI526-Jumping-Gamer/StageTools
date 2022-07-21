using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionTrigger : MonoBehaviour
{
    bool isFirstTime = true;
    [SerializeField] GameObject window;
    [SerializeField] GameObject settingPanel;
    TimeControl timeControl;
    void start()
    {
        timeControl = FindObjectOfType<TimeControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isFirstTime)
            {
                settingPanel.SetActive(false);
                PlayerController.instance.DisablePlayerInput();
                window.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        settingPanel.SetActive(true);
        isFirstTime = false;
    }
}
