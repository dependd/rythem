using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolBanar : MonoBehaviour
{
    public List<GameObject> banars = new List<GameObject>();

    Vector2 points;
    Vector2 endPoint;
    float dis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
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
    
    void MoveBanar(int plus,float speed)
    {
        for (int i = 0;i < banars.Count;i++)
        {
            banars[i].transform.position += new Vector3(0, speed,0) * plus;
        }
    }
    
    IEnumerator SnapBanar(int plus,float speed)
    {
        float move = speed;
        while (move >= 0.1f)
        {
            for (int i = 0; i < banars.Count; i++)
            {
                banars[i].transform.position += new Vector3(0, move, 0) * plus;
            }
            move -= 0.5f;
            yield return null;
        }
    }
}
