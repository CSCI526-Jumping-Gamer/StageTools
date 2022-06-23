using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    // [SerializeField] ParticleSystem crashEffect;
    PlayerController playerController;
    [SerializeField] GameObject player;
    
    // [SerializeField] AudioClip crashSFX;
    // Start is called before the first frame update
    private void Awake() {
        playerController = player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // crashEffect.Play();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            int shieldCount = playerController.GetShieldCount();

            if (shieldCount > 0) {
                playerController.SetShieldCount(shieldCount - 1);
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
