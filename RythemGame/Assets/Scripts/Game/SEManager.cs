using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    AudioSource source;

    [SerializeField]AudioClip[] clips;

    private void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    public void PlaySE()
    {
        source.Play();
    }

    public void SetSE(int num)
    {
        source.clip = clips[num];
        PlaySE();
    }
}
