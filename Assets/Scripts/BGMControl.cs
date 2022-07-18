using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip audioClip = null;
    
    [SerializeField] AudioClip audioClipBackUp;
    void Start()
    {
        if (audioClip != null) {
            BackgroundMusic.bgm.PlayClip(audioClip);
            BackgroundMusic.isLoadMusic = false;
        } else if (BackgroundMusic.isLoadMusic) {
            BackgroundMusic.bgm.PlayClip(audioClipBackUp);
        }
        
    }

    
}
