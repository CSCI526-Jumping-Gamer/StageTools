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
    [SerializeField] bool isResetLevels = false;

    private static string[] ROMAN_NUMBER = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };


    private void Awake() {
        InitLevels();
    }

    private void Start()
    {
        SetLevelsRank();
    }

    private void Update() {
        if (isResetLevels) {
            PlayerPrefs.SetInt("levelAt", 2);
            LockLevels();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
    

    private void InitLevels() {
        if (!PlayerPrefs.HasKey("levelAt")) {
            PlayerPrefs.SetInt("levelAt", 1);
        }
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelsText.Length; i++) {
            levelsText[i].text = "LEVEL " + ROMAN_NUMBER[i + 1].ToString();
        }
    }

    private void SetLevelsRank() {
        for (int i = 0; i < levelsButton.Length; i++) {
            // Get level rank: 0, 1, 2 ,3
            int levelRank = PlayerPrefs.GetInt("Level " + (i + 1));
            // Debug.Log("levelRank " + levelRank);

            // Unlock Levels
            int levelAt = PlayerPrefs.GetInt("levelAt", 1);
            if (i + 1 > levelAt)
            {
                levelsButton[i].GetComponent<Button>().interactable = false;
            }

            GameObject starOne = levelsButton[i].transform.GetChild(1).gameObject;
            GameObject starTwo = levelsButton[i].transform.GetChild(2).gameObject;
            GameObject starThree = levelsButton[i].transform.GetChild(3).gameObject;
        
            // Set Ranks
            if (levelRank == 3) {
                // 3 stars
                // SetImageColor(new Color32(255, 215, 0, 255), i);
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(true);
            } else if (levelRank == 2) {
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(false);
            } else if (levelRank == 1) {
                // 1 stars
                // SetImageColor(new Color32(184, 134, 11, 255), i);
                starOne.SetActive(true);
                starTwo.SetActive(false);
                starThree.SetActive(false);
            } else {
                // original color
                // SetImageColor(new Color32(255, 255, 255, 255), i);
                starOne.SetActive(false);
                starTwo.SetActive(false);
                starThree.SetActive(false);
            }
        }
    }
  // Debug.Log(levelAt);
 

    public void OpenScene(int level) {
        SceneManager.LoadScene(level);
        BackgroundMusic.isLoadMusic = true;
    }

    private void LockLevels() {
        for (int i = 0; i < levelsButton.Length; i++) {
            // SetImageColor(new Color32(150, 186, 243, 255), i);         
            PlayerPrefs.SetInt("Level " + (i + 1), 0); 
            if (i > 0) {
                levelsButton[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void UnlockLevels() {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelsButton.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelsButton[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    // private void SetImageColor(Color32 colors, int index) {
    //     levelsButton[index].GetComponent<Image>().color = colors;
    // }

}
