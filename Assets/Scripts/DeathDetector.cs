using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Services.Analytics
{
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] float loadDelay = 0.5f;
        // [SerializeField] ParticleSystem crashEffect;
        PlayerController playerController;
        // [SerializeField] AudioClip crashSFX;

        [SerializeField] bool isLevel2;
        Teleporter teleporter;
        private void Awake() {
            playerController = FindObjectOfType<PlayerController>();
            teleporter = FindObjectOfType<Teleporter>();
        }
        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Player") {
                // crashEffect.Play();
                // GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Debug.Log("player died");
                AnalyticsService.Instance.CustomData("playerDied", new Dictionary<string, object>());
                Invoke("ReloadScene", loadDelay);
            }
        }
        void ReloadScene() {
            if (!isLevel2) {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            } else {
                teleporter.Respawning();
            }
        }
    }
}