using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    //現在がどのシーンか
    enum Scene
    {
        Title,
        Select,
        Setting
    }
    [SerializeField]private Scene scene;


    //タイミング作成用変数
    [SerializeField] GameObject startButton;
    [SerializeField] StartGame sg;
    [SerializeField] NoteTimingMaker note;

    //各シーンのUIの親オブジェクト
    [SerializeField] GameObject start;
    [SerializeField] GameObject select;
    [SerializeField] GameObject setting;
    //選択シーンのバナーのプレハブ
    [SerializeField] GameObject banar;
    
    // Use this for initialization
    void Start()
    {
        scene = Scene.Title;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TimingStart()
    {
        startButton.SetActive(false);
        note.StartMusic();
        sg.BGMStart();
        //レーンをアクティブ化
        //該当の譜面をサーチ
        //ゲームスタート
    }
    public void GameStart()
    {
        SceneManage.instance.ChangeMainScene();
    }
    public void HomeScene()
    {
        scene = Scene.Title;
    }
    //スタートボタンから楽曲選択へ移行する関数
    public void SelectScene()
    {
        scene = Scene.Select;
        select.GetComponent<SelectScene>().SetInfo();
    }

    public void SettingScene()
    {
        scene = Scene.Setting;
        setting.GetComponent<Setting>().SetInit();
    }

    public void NextScene()
    {
        switch (scene)
        {
            case Scene.Title:
                start.SetActive(false);
                select.SetActive(true);
                SelectScene();
                break;
            case Scene.Select:
                select.SetActive(false);
                setting.SetActive(true);
                SettingScene();
                break;
            case Scene.Setting:
                SceneManage.instance.ChangeMainScene();
                break;
        }
    }

    public void BackScene()
    {
        switch (scene)
        {
            case Scene.Select:
                foreach (Transform obj in select.transform)
                {
                    if (obj.GetComponent<Banar>())
                    {
                        Destroy(obj.gameObject);
                    }
                }
                select.GetComponent<SelectScene>().ReSetbanar();
                select.SetActive(false);
                start.SetActive(true);
                scene = Scene.Title;
                break;
            case Scene.Setting:
                setting.SetActive(false);
                select.SetActive(true);
                scene = Scene.Select;
                break;
            case Scene.Title:                
                //ゲーム終了確認
                break;
        }
    }
}