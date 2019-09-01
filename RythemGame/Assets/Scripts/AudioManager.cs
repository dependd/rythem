using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ChangeBGM()
    {
        audio.clip = GamePlayManager.instance.param.music;
        audio.Play();
    }
}
