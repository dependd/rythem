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
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void ChangeHomeScene()
    {
        SceneManager.LoadScene("Home");
    }
    public void ChangeStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void ChangeResultScene()
    {
        SceneManager.LoadScene("Result");
    }

    public void Test()
    {

    }
}
