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
    private Scene scene;


    //タイミング作成用変数
    [SerializeField] GameObject startButton;
    [SerializeField] StartGame sg;
    [SerializeField] NoteTimingMaker note;

    //各シーンのUIの親オブジェクト
    [SerializeField] GameObject start;
    [SerializeField] GameObject select;
    ScroolBanar scroolBanar;
    [SerializeField] GameObject setting;
    //選択シーンのバナーのプレハブ
    [SerializeField] GameObject banar;
    // Use this for initialization
    void Start()
    {
        scene = Scene.Title;
        scroolBanar = select.GetComponent<ScroolBanar>();
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

        var selectScript = select.GetComponent<SelectScene>();
        
        //バナーを配置するpositionのY軸を設定する
        float PlusNum = (Screen.height - 250) / 4;
        float posY = Screen.height / 2;
        //楽曲数分回す
        for (int i = 0; i < selectScript.expretions.Length; i++)
        {
            Debug.Log(posY);
            //楽曲ごとのバナーをinstance
            //バナーの数をlistで取得しておく
            scroolBanar.banars.Add(Instantiate(banar, new Vector3(transform.position.x, posY, transform.position.z), Quaternion.identity, select.transform));
            posY += PlusNum;
            if (i > 3 && i < selectScript.expretions.Length - 3)
            {
                scroolBanar.banars[i].SetActive(false);
            }else if (i >= selectScript.expretions.Length - 3)
            {
                scroolBanar.banars[i].transform.position = new Vector3();
            }
        }

    }

    public void SettingScene()
    {
        scene = Scene.Setting;
        foreach (Transform obj in select.transform){
            Destroy(obj.gameObject);
        }
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
                foreach (Transform obj in select.transform)
                {
                    Destroy(obj.gameObject);
                }
                select.SetActive(true);
                setting.SetActive(false);SelectScene();
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
                    Destroy(obj.gameObject);
                }
                select.SetActive(false);
                start.SetActive(true);
                break;
            case Scene.Setting:
                foreach (Transform obj in setting.transform)
                {
                    Destroy(obj.gameObject);
                }
                setting.SetActive(false);
                select.SetActive(true);
                
                break;
            case Scene.Title:                
                //ゲーム終了確認
                break;
        }
    }
}