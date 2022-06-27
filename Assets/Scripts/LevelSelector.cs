using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelSelector : MonoBehaviour
{
    [SerializeField] int level = 0;
    private TextMeshProUGUI levelText;

    private void Start() {
       if (levelText = gameObject.GetComponentInChildren<TextMeshProUGUI>()) {
            Debug.Log(levelText.text);
            levelText.text = "Level " + level.ToString();
       }
       
    }

    public void OpenScene() {
        SceneManager.LoadScene(level);
    }
}
