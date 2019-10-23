using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    [SerializeField] int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void BGMStart()
    {
        audioSource.clip = clips[i];
        audioSource.Play();
    }

}
