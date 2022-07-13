using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelHandler : MonoBehaviour
{
    [SerializeField] GameObject[] levelsButton;
    [SerializeField] TextMeshProUGUI[] levelsText;
    [SerializeField] bool isLockLevels = false;
    private void Start()
    {
        InitLevels();
        SetLevelsRank();
    }
    private void Update() {
        if (isLockLevels) {
            PlayerPrefs.SetInt("levelAt", 2);
            ResetLevelColor();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

   
    

    private void InitLevels() {
        if (!PlayerPrefs.HasKey("levelAt")) {
            PlayerPrefs.SetInt("levelAt", 2);
        }
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        Debug.Log(levelAt);
        for (int i = 0; i < levelsButton.Length; i++)
        {
            // levelsButton[i].GetComponent<Button>().interactable = false;
            if (i + 2 > levelAt)
            {
                levelsButton[i].GetComponent<Button>().interactable = false;
            }
        }

        for (int i = 0; i < levelsText.Length; i++) {
            levelsText[i].text = "Level " + (i + 1).ToString();
        }
        
    }

    private void SetLevelsRank() {
        for (int i = 0; i < levelsButton.Length; i++) {

            int levelRank = PlayerPrefs.GetInt("Level " + (i + 1));
            Debug.Log("levelRank " + levelRank);
            if (levelRank == 3) {
                // Gold
                SetImageColor(new Color32(255, 215, 0, 255), i);
            } else if (levelRank == 2) {
                // Silver
                SetImageColor(new Color32(192, 192, 192, 255), i);
            } else if (levelRank == 1) {
                // Brown
                SetImageColor(new Color32(184, 134, 11, 255), i);
            } else {
                // original color
                SetImageColor(new Color32(150, 186, 243, 255), i);
            }
        }
    }

    public void OpenScene(int level) {
        SceneManager.LoadScene(level);
    }

    private void ResetLevelColor() {
        for (int i = 0; i < levelsButton.Length; i++) {
            // SetImageColor(new Color32(150, 186, 243, 255), i);         
            PlayerPrefs.SetInt("Level " + (i + 1), 0); 
        }
    }

    private void SetImageColor(Color32 colors, int index) {
        levelsButton[index].GetComponent<Image>().color = colors;
    }

}
