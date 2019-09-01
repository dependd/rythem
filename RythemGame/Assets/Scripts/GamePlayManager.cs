using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : SingletonMonoBehaviour<GamePlayManager>
{
    public MusicExpretion param;
    public string passName;
   
    public void SetPassName(int level)
    {
        if (level == 0)
        {
            passName = "CSV/Easy/" + param.musicName;
        }else if(level == 1)
        {
            passName = "CSV/Hard/" + param.musicName;
        }
    }
}
