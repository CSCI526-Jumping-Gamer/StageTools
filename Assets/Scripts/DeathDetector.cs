using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    // [SerializeField] ParticleSystem crashEffect;
    PlayerController playerController;
    // [SerializeField] AudioClip crashSFX;
    // Start is called before the first frame update
    [SerializeField] bool isLevel2;
    RespawnPlayer respawnPlayer;
    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
        respawnPlayer = FindObjectOfType<RespawnPlayer>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // crashEffect.Play();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene() {
        if (!isLevel2) {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        } else {
            respawnPlayer.Respawning();
        }
    }
}