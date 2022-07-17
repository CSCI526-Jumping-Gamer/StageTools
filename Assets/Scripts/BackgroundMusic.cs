using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioSource;

    public AudioSource AudioSource => _audioSource;

    // Others can only read
    // Only this class can set the value
    public static BackgroundMusic bgm {get; private set;}
    void Awake()
    {
        if (bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }

         if(!_audioSource) _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }


}
