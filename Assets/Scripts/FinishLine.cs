using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            finishEffect.Play();
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
