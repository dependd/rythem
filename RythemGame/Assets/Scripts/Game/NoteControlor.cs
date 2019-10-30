using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteControlor : MonoBehaviour {
    public enum Note
    {
        tap,
        hold,
        flick
    }
    public Note noteData;
    UIManager _UIManager;
    GameControlor controlor;
    ScoreManager scoreManager;
    int hs;
    public float timing;
	// Use this for initialization
	void Start () {
        controlor = GameObject.Find("GameController").GetComponent<GameControlor>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        hs = controlor.highSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * (5f + (float)(hs / 2f)) * Time.deltaTime;

        //if (timing <= controlor.GetMusicTime())
        //{
        //    Destroy(this.gameObject);
        //}
        if (transform.position.y <= -5)
        {
            Miss();
        }
	}

    private void Miss()
    {
        Debug.Log(false);
        controlor._LineCheckNoteCount++;
        controlor.combo = 0;
        controlor.hanteis[4]++;
        scoreManager.AddScore(4);
        _UIManager.ComboCount(controlor.combo);
        _UIManager.Hantei("Miss");
        Destroy(this.gameObject);
    }
}
