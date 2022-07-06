using UnityEngine;
using UnityEngine.SceneManagement;
public class Scoreboard : MonoBehaviour
{

    [SerializeField] GameObject wrapper;
    public static int score = 1;

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        if (nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneIndex);
        }


    }
}
