using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip click;
    private AudioSource audio;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else 
        instance = this;

        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void ClickSfx(){
        audio.PlayOneShot(click);
    }
}
