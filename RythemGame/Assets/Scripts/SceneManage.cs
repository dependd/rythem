using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : SingletonMonoBehaviour<SceneManage> {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void Test()
    {

    }
}
