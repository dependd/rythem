﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] SpriteRenderer jacket;
    [SerializeField] GameObject exe;
    [SerializeField] Text score;
    [SerializeField] Text combo;

    // Start is called before the first frame update
    void Start()
    {
        MusicExpretion param = GamePlayManager.instance.param;
        name.text = param.musicName;
        //ジャケット
        score.text = GamePlayManager.instance.Score.ToString();
        combo.text = GamePlayManager.instance.MaxCombo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManage.instance.ChangeHomeScene();
    }
}
