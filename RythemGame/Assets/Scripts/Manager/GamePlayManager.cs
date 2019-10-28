using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : SingletonMonoBehaviour<GamePlayManager>
{
    public MusicExpretion param;
    public string passName;

    public int MaxCombo;
    public int Score;

    public int[] hantei;
    public int HS;
   
    public void SetPassName(int level)
    {
        if (level == 0)
        {
            passName = "CSV/Easy/" + param.PassName;
        }else if(level == 1)
        {
            passName = "CSV/Hard/" + param.PassName;
        }
    }
}
