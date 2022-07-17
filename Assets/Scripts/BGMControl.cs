using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        BackgroundMusic.bgm.PlayClip(audioClip);
    }

    
}
