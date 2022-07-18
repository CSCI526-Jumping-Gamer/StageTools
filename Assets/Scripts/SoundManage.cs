using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManage : MonoBehaviour
{
    [SerializeField] Slider volumeController;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
        } 
        
        
        Load();
    }

    // private void Start() {
    //     Debug.Log("musicVolume: " + PlayerPrefs.GetFloat("musicVolume"));
    //     Load();
    // }

    
    public void changeVolume() {
        AudioListener.volume = volumeController.value;
        save();
        
    }

    private void Load() {
        volumeController.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save() {
        PlayerPrefs.SetFloat("musicVolume", volumeController.value);
    }

    
}
