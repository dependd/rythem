using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteControlor : MonoBehaviour {
    UIManager _UIManager;
    GameControlor controlor;
    int hs;
    public float timing;
	// Use this for initialization
	void Start () {
        controlor = GameObject.Find("GameController").GetComponent<GameControlor>();
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        hs = controlor.highSpeed;
        Debug.Log((5f + (float)(hs / 2f)));
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
        _UIManager.ComboCount(controlor.combo);
        _UIManager.Hantei("Miss");
        Destroy(this.gameObject);
    }
}
