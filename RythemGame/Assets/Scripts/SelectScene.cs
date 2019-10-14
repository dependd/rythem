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

    [SerializeField]ButtonScripts button;

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Banar>() != null)
            {
                //バナーに情報を入れる関数を呼ぶ
                child.GetComponent<Banar>().SetInfo(expretions[count]);
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
                GamePlayManager.instance.param = hit.collider.gameObject.GetComponent<Banar>().parameter;
                GamePlayManager.instance.SetPassName((int)level);
                button.NextScene();

            }

        }
    }
}
