using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]Text HStext;
    int highSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        SetHS();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetHS()
    {
        HStext.text = highSpeed.ToString();
        GamePlayManager.instance.HS = highSpeed;
    }

    public void ChangeHS(bool plus)
    {
        if (plus)
        {
            if (highSpeed >= 10) return;
            highSpeed++;
        }
        else
        {
            if (highSpeed <= 1) return;
            highSpeed--;
        }
        SetHS();
    }
}
