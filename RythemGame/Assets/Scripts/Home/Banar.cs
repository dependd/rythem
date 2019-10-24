using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banar : MonoBehaviour
{
    [SerializeField] Text level;//難易度
    [SerializeField] Text name;//楽曲名


    public MusicExpretion parameter;
    /// <summary>
    /// バナーの情報を入力
    /// </summary>
    /// <param name="parameter"></param>
    public void SetInfo(MusicExpretion param)
    {
        parameter = param;
        level.text = "Level : " + parameter.difficulity[1].ToString();
        name.text = parameter.musicName;
    }

    public void SetLevel(int num)
    {
        level.text = "Level : " + parameter.difficulity[num].ToString();
    }
}
