﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolBanar : MonoBehaviour
{
    public List<GameObject> banars = new List<GameObject>();
    
    Vector2 points;//最初にタップした場所
    Vector2 endPoint;//次のフレームでタップした場所
    float dis;
    //スクロールしたときにバナーが移動する上限
    public float changePosition;
    //真ん中で選択されてる楽曲
    public GameObject centerBanar;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void Update()
    {
        //弾く動作を取得するスクリプト
        if (Input.GetMouseButtonDown(0))
        {
            points = Input.mousePosition;
        }else if (Input.GetMouseButton(0))
        {
            endPoint = Input.mousePosition;
            dis = Vector2.Distance(points, endPoint);
            if (endPoint.y < points.y)
            {
                MoveBanar(-1,dis);
            }
            else if(endPoint.y > points.y)
            {
                MoveBanar(1,dis);
            }
            points = endPoint;
        }else if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition;
            dis = Vector2.Distance(points, endPoint);
            Debug.Log(dis);
            if (dis == 0)
            {
                SenterStop();
                return;
            }
            if (endPoint.y < points.y)
            {
                StartCoroutine(SnapBanar(-1, dis));
            }
            else if (endPoint.y > points.y)
            {
                StartCoroutine(SnapBanar(1, dis));
            }
        }
        if (Input.touchCount < 1) return;
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            points = touch.position;
        }else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            endPoint = touch.position;
            dis = Vector2.Distance(points, endPoint);
            if (endPoint.y < points.y)
            {
                MoveBanar(-1, dis);
            }
            else if (endPoint.y > points.y)
            {
                MoveBanar(1, dis);
            }
            points = endPoint;
        }else if (touch.phase == TouchPhase.Ended)
        {
            endPoint = touch.position;
            dis = Vector2.Distance(points, endPoint);
            Debug.Log(dis);
            if (dis == 0)
            {
                SenterStop();
                return;
            }
            if (endPoint.y < points.y)
            {
                StartCoroutine(SnapBanar(-1, dis));
            }
            else if (endPoint.y > points.y)
            {
                StartCoroutine(SnapBanar(1, dis));
            }
        }
    }

    public void SetInit()
    {
        centerBanar = banars[0];
        GetComponent<SelectScene>().SetJacket(centerBanar);
        centerBanar.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    //タップしながら動かしたとき
    void MoveBanar(int plus,float speed)
    {
        centerBanar.transform.localScale = new Vector3(1,1,1);
        for (int i = 0;i < banars.Count;i++)
        {
            banars[i].transform.position += new Vector3(0, speed, 0) * plus;
            if (banars[i].transform.position.y >= changePosition)
            {
                banars[i].transform.position = new Vector3(Screen.width - Screen.width / 4, -changePosition + Screen.height - 75, 0);
            }
            else if (banars[i].transform.position.y <= -changePosition + Screen.height - 75)
            {
                banars[i].transform.position = new Vector3(Screen.width - Screen.width / 4, changePosition, 0);
            }
        }
    }
    //弾いたとき
    IEnumerator SnapBanar(int plus,float speed)
    {
        centerBanar.transform.localScale = new Vector3(1, 1, 1);
        float move = speed;
        while (move >= 0.1f)
        {
            for (int i = 0; i < banars.Count; i++)
            {
                banars[i].transform.position += new Vector3(0, move, 0) * plus;
                if (banars[i].transform.position.y >= changePosition)
                {
                    banars[i].transform.position = new Vector3(Screen.width - Screen.width / 4, -changePosition + 1 + Screen.height - 75, 0);
                }
                else if (banars[i].transform.position.y <= -changePosition + Screen.height - 75)
                {
                    banars[i].transform.position = new Vector3(Screen.width - Screen.width / 4, changePosition - 1, 0);
                }
            }
            move -= 0.5f;
            yield return null;
        }
        SenterStop();
    }
    
    /// <summary>
    /// 真ん中のバナーを取得する
    /// </summary>
    private void SenterStop()
    {
        Vector2 position = Vector2.zero;
        bool isSet = true;
        float dis = 1000;
        for (int i = 0;i< banars.Count;i++)
        {
            Debug.Log(banars[i].name + " : screen.height - Mathf.abs : " + (Mathf.Abs(Screen.height - Mathf.Abs(banars[i].transform.position.y)) - Screen.height / 2) + " / dis : " + dis + " / position : " + banars[i].transform.position.y);
            if (Mathf.Abs(Screen.height - Mathf.Abs(banars[i].transform.position.y) - Screen.height / 2)<= dis)
            {
                dis = (Mathf.Abs(Screen.height - Mathf.Abs(banars[i].transform.position.y) - Screen.height / 2));
                centerBanar = banars[i];
                GetComponent<SelectScene>().SetJacket(centerBanar);
            }
        }
        Debug.Log(centerBanar.name);
        //バナーの位置を修正
        if (centerBanar.transform.position.y > Screen.height / 2) dis *= -1;
        for (int i = 0; i < banars.Count; i++)
        {
            banars[i].transform.position += new Vector3(0,dis ,0);
        }
        centerBanar.transform.localScale = new Vector3(1.3f,1.3f,1.3f);
    }
}
