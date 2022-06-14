using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] int sceneNumber = 0;
    // [SerializeField] ParticleSystem crashEffect;
    PlayerMovement playerMovement;
    // [SerializeField] AudioClip crashSFX;
    // Start is called before the first frame update
    private void Awake() {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // crashEffect.Play();
            playerMovement.OnDisable();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene() {
        SceneManager.LoadScene(sceneNumber);
    }
}