using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] Button[] levelButton;
    private void Start() {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButton.Length; i++) {
            if (i + 2 > levelAt) {
                levelButton[i].interactable = false;
            }
        }

    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }
    
}
