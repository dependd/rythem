using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //スコアの最大値。いわゆる理論値
    const int MaxScore = 10000000;//百万
    //1ノーツごとのスコア
    private float OneNoteScore;

    // 現在のスコア
    [SerializeField]private int Score;

    [SerializeField] UIManager _UIManager;
    //
    [Header("上からGreat,Fine,Good。100%=1,1%=0.01で表記")]
    [SerializeField] float[] bairitu = new float[3];

    //判定数管理用の配列
    private int[] hanteis = new int[5];

    /// <summary>
    /// スコアのゲッターセッター
    /// </summary>
    public int ScoreInfo
    {
        get { return Score; }
        set { Score = value; }
    }

    /// <summary>
    /// Great時(100%)の1ノーツの加算スコアを出しておく
    /// </summary>
    /// <param name="MaxConbo">総ノーツ数</param>
    public void SetOnNoteScore(float MaxConbo)
    {
        OneNoteScore = MaxScore / MaxConbo;
    }

    // Start is called before the first frame update
    void Start()
    {
        //float maxcombo = 2222;
        //SetOnNoteScore(maxcombo);
        /*
        for (int i = 0;i< maxcombo;i++)
        {
            AddScore(0);
        }
        Debug.Log("score : " + Score);
        */
    }
    float time;
    int cnt;
    private void Update()
    {
        //if (true) return;
        //if (time >= 1 && cnt < 2222)
        //{
        //    time = 0;
        //    if (cnt % 10 == 0)
        //    {
        //        AddScore(1);
        //    }
        //    else
        //    {
        //        AddScore(0);
        //    }
        //    cnt++;
        //}
        //else if (cnt == 2222)
        //{
        //    Debug.Log("score : " + Score + " / great : " + hanteis[0] + " / good : " + hanteis[1]);
        //}
        //time++;
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    public void AddScore(int i)
    {
        hanteis[i]++;
        Score = ScoreCuliculate(i);
        _UIManager.ScoreUp(Score);
    }

    float amari;

    /// <summary>
    /// スコア計算
    /// </summary>
    private int ScoreCuliculate(int hantei)
    {
        /*
        float bairitu = 0;
        int score;
        switch (hantei)
        {
            //Great
            case 0:
                bairitu = 1;
                break;
            //Fine
            case 1:
                bairitu = 0.7f;
                break;
            //Good
            case 2:
                bairitu = 0.4f;
                break;
            //Miss
            case 3:
                bairitu = 0;
                break;
            default:
                Debug.LogError("判定の引数が間違っています");
                break;
        }
        if(OneNoteScore == 0)
        {
            Debug.LogError("1ノーツの加算スコアが計算されていません");
        }
        //ここから計算
        float floatScore = OneNoteScore * bairitu;//まず1ノーツスコアに倍率乗算
        float num = Mathf.Floor(floatScore);//乗算した値を切り捨て
        amari += floatScore - num;//小数点以下を保持
        if(amari >= 1)//保持している小数点以下が1を超えたら
        {
            amari = amari - 1;
            floatScore++;
        }

        return (int)Mathf.Floor(floatScore);//切り捨てした値をreturn
        */

        //判定数の配列から各判定ごとの回数を倍率で計算
        return ((int)Mathf.Floor(OneNoteScore * hanteis[0] * bairitu[0])
              + (int)Mathf.Floor(OneNoteScore * hanteis[1] * bairitu[1])
              + (int)Mathf.Floor(OneNoteScore * hanteis[2] * bairitu[2])
              + (int)Mathf.Floor(OneNoteScore * hanteis[3] * bairitu[3]));
    }

}
