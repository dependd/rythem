using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float time;
    Text text;
    [SerializeField]NoteTimingMaker maker;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        text = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maker._isPlaying)
        {
            time += Time.deltaTime;
            text.text = time.ToString();
        }
    }
}
