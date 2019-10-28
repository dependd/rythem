using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : MonoBehaviour
{
    public enum Level
    {
        Easy,
        Hard
    }
    public Level level;
    //楽曲の情報のscriptableObjectを入れる配列
    public MusicExpretion[] expretions;
    //真ん中で選択されてる楽曲
    GameObject selected;

    [SerializeField] GameObject banar;

    [SerializeField]ButtonScripts button;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetInfo()
    {
        var scroolScript = GetComponent<ScroolBanar>();
        //バナーを配置するpositionのY軸を設定する
        float PlusNum = 75;
        float posY = Screen.height / 2;
        //楽曲数分回す
        for (int i = 0; i < expretions.Length; i++)
        {
            Debug.Log(posY);
            //楽曲ごとのバナーをinstance
            //バナーの数をlistで取得しておく
            scroolScript.banars.Add(Instantiate(banar, new Vector3(transform.position.x, posY, transform.position.z), Quaternion.identity, this.gameObject.transform));
            posY += PlusNum;
            if (i == expretions.Length / 2)
            {
                scroolScript.changePosition = scroolScript.banars[i].transform.position.y;
                posY = -posY + Screen.height + PlusNum;
            }
        }
        int count = 0;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Banar>() != null)
            {
                //バナーに情報を入れる関数を呼ぶ
                child.GetComponent<Banar>().SetInfo(expretions[count]);
                child.name = expretions[count].name;
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //マウスポジションからrayを飛ばして楽曲選択
            Vector2 pos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit.collider)
            {
                GamePlayManager.instance.param = GetComponent<ScroolBanar>().centerBanar.GetComponent<Banar>().parameter;
                GamePlayManager.instance.SetPassName((int)level);
                button.NextScene();
            }

        }
    }
}
