using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    // [SerializeField] ParticleSystem crashEffect;
    PlayerMovement playerMovement;
    [SerializeField] GameObject player;
    
    // [SerializeField] AudioClip crashSFX;
    // Start is called before the first frame update
    private void Awake() {
        // playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // crashEffect.Play();
            // playerMovement.OnDisable();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            int shieldCount = playerMovement.GetShieldCount();

            if (shieldCount > 0) {
                playerMovement.SetShieldCount(shieldCount - 1);
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
