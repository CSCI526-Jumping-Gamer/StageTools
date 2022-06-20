using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted")) {
            PlayerPrefs.SetInt("muted", 0); 
        }
        Load();
        UpdateSoundIcon();
        AudioListener.pause = muted;

    }

    public void onPress() {
        if (muted) {
            muted = false;
            AudioListener.pause = false;
        } else {
            muted = true;
            AudioListener.pause = true;
        }
        Save();
        UpdateSoundIcon();
    }


    private void Load() {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save() {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    private void UpdateSoundIcon() {
        if (muted) {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        } else {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
    }
    
}
