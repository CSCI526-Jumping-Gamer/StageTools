using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    // [SerializeField] ParticleSystem crashEffect;
    // [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // crashEffect.Play();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX); 

            if (PlayerController.instance.shieldCount > 0) {
                PlayerController.instance.shieldCount -= 1;
            } else {
                Invoke("ReloadScene", loadDelay);
            }
        }
    }
    void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
