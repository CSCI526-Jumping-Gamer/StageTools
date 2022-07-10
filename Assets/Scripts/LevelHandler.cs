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

    private void update() {
        if (isLockLevels) {
            PlayerPrefs.SetInt("levelAt", 2);
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

    }

    public void OpenScene(int level) {
        SceneManager.LoadScene(level);
    }

}
