using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolBanar : MonoBehaviour
{
    public List<GameObject> banars = new List<GameObject>();
    
    Vector2 points;//最初にタップした場所
    Vector2 endPoint;//次のフレームでタップした場所
    float dis;

    public float changePosition;
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
            if (dis == 0) return;
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
    //タップしながら動かしたとき
    void MoveBanar(int plus,float speed)
    {
        for (int i = 0;i < banars.Count;i++)
        {
            banars[i].transform.position += new Vector3(0, speed,0) * plus;
            if (banars[i].transform.position.y >= changePosition)
            {
                Debug.Log(banars[i].name +" : up");
                banars[i].transform.position = new Vector3(transform.position.x, -changePosition + 1 + Screen.height - 75, 0);
            } else if (banars[i].transform.position.y <= -changePosition + Screen.height - 75)
            {
                Debug.Log(banars[i].name + " : down");
                banars[i].transform.position = new Vector3(transform.position.x, changePosition - 1, 0);
            }
        }
    }
    //弾いたとき
    IEnumerator SnapBanar(int plus,float speed)
    {
        float move = speed;
        while (move >= 0.1f)
        {
            for (int i = 0; i < banars.Count; i++)
            {
                banars[i].transform.position += new Vector3(0, move, 0) * plus;
                if (banars[i].transform.position.y >= changePosition)
                {
                    Debug.Log(banars[i].name + " : up");
                    banars[i].transform.position = new Vector3(transform.position.x, -changePosition + 1 + Screen.height - 75, 0);
                }
                else if (banars[i].transform.position.y <= -changePosition + Screen.height - 75)
                {
                    Debug.Log(banars[i].name + " : down");
                    banars[i].transform.position = new Vector3(transform.position.x, changePosition - 1, 0);
                }
            }
            move -= 0.5f;
            yield return null;
        }
    }
    
}
