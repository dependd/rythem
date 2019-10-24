using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Music/Create MusicException", fileName = "MusicException")]
public class MusicExpretion : ScriptableObject
{
    [SerializeField]
    [Header("楽曲名")]
    public string musicName;


    [SerializeField]
    [Header("ファイルパスネーム")]
    public string PassName;

    [SerializeField]
    [Header("難易度")]
    public int[] difficulity;

    [SerializeField]
    [Header("ジャケット")]
    public Sprite jacket;

    [SerializeField]
    [Header("楽曲")]
    public AudioClip music;
}
