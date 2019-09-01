using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameControlor : MonoBehaviour {

    [SerializeField] UIManager _UIManager;
    [SerializeField] GameObject audioSource;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject[] NoteLine;
    public int score;
    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;
    public int combo = 0;

    private int maxCombo;
    public string filePass;
    private int _SpawndNotesCount = 0;
    public int _LineCheckNoteCount = 0;
    
    private float _startTime = 0;

    public float timeOffset = 0;

    private bool _isPlaying = false;
    public GameObject startButton;

    float timing;
    public int highSpeed;

    void Start()
    {
        InstanceTiming(highSpeed);
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV();
        score = 0;
        StartCoroutine(ReadyGo());
    }

    void Update()
    {
        if (_isPlaying)
        {
            CheckNextNotes();
            CheckKey();
        }

    }

    public void StartGame()
    {
        //startButton.SetActive(false);
        _startTime = Time.time;
        audioSource.GetComponent<AudioManager>().ChangeBGM();
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (_timing[_SpawndNotesCount] + timeOffset < GetMusicTime() - timing && _timing[_SpawndNotesCount] != 0)
        {
            SpawnNotes(_lineNum[_SpawndNotesCount]);
            _SpawndNotesCount++;
        }
    }
    private void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (NoteLine[0].transform.childCount == 0) return;
            var noteObj = NoteLine[0].GetComponentInChildren<NoteControlor>().gameObject;
            //if (CheckNoteTiming(0,noteObj))
            //{
            //    Debug.Log("line0 == true");
            //    SuccessTap(noteObj);
            //}
            //else 
            //{
            //    MissTap(noteObj);
            //}
            switch (CheckNoteTiming(0, noteObj))
            {
                case "Parfect":
                    Debug.Log("line0 == true");
                    SuccessTap(noteObj);
                    break;
                case "Miss":
                    Debug.Log("miss");
                    MissTap(noteObj);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log(GetMusicTime());
            if (NoteLine[1].transform.childCount == 0) return;
            var noteObj = NoteLine[1].GetComponentInChildren<NoteControlor>().gameObject;
            //if (CheckNoteTiming(1,noteObj))
            //{
            //    Debug.Log("line1 == true");
            //    SuccessTap(noteObj);
            //}
            //else
            //{
            //    MissTap(noteObj);
            //}
            switch (CheckNoteTiming(1, noteObj))
            {
                case "Parfect":
                    Debug.Log("line1 == true");
                    SuccessTap(noteObj);
                    break;
                case "Miss":
                    Debug.Log("miss");
                    MissTap(noteObj);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NoteLine[2].transform.childCount == 0) return;
            var noteObj = NoteLine[2].GetComponentInChildren<NoteControlor>().gameObject;
            //if (CheckNoteTiming(2,noteObj))
            //{
            //    Debug.Log("line2 == true");
            //    SuccessTap(noteObj);
            //}
            //else
            //{
            //    MissTap(noteObj);
            //}
            switch (CheckNoteTiming(2, noteObj))
            {
                case "Parfect":
                    Debug.Log("line2 == true");
                    SuccessTap(noteObj);
                    break;
                case "Miss":
                    Debug.Log("miss");
                    MissTap(noteObj);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log(GetMusicTime());
            if (NoteLine[3].transform.childCount == 0) return;
            var noteObj = NoteLine[3].GetComponentInChildren<NoteControlor>().gameObject;
            //if (CheckNoteTiming(3,noteObj))
            //{
            //    Debug.Log("line3 == true");
            //    SuccessTap(noteObj);
            //}
            //else
            //{
            //    MissTap(noteObj);
            //}
            switch (CheckNoteTiming(3, noteObj))
            {
                case "Parfect":
                    Debug.Log("line3 == true");
                    SuccessTap(noteObj);
                    break;
                case "Miss":
                    Debug.Log("miss");
                    MissTap(noteObj);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (NoteLine[4].transform.childCount == 0) return;
            var noteObj = NoteLine[4].GetComponentInChildren<NoteControlor>().gameObject;
            //if (CheckNoteTiming(4,noteObj))
            //{
            //    Debug.Log("line4 == true");
            //    SuccessTap(noteObj);
            //}
            //else
            //{
            //    MissTap(noteObj);
            //}
            switch(CheckNoteTiming(4, noteObj))
            {
                case "Parfect":
                    Debug.Log("line4 == true");
                    SuccessTap(noteObj);
                    break;
                case "Miss":
                    Debug.Log("miss");
                    MissTap(noteObj);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach(Object i in NoteLine[1].transform){
                Debug.Log(i);
            }
        }
    }
    void SuccessTap(GameObject line)
    {
        combo++;
        score += 200;
        _UIManager.ComboCount(combo);
        _UIManager.ScoreUp(score);
        Destroy(line);
        _LineCheckNoteCount++;
    }
    void MissTap(GameObject obj)
    {

        Debug.Log(false);
        _LineCheckNoteCount++;
        combo = 0;
        _UIManager.ComboCount(combo);
        Destroy(obj);
    }

    //判定
    string CheckNoteTiming(int num,GameObject lineObj)
    {
        if (lineObj.GetComponentInChildren<NoteControlor>().timing + timeOffset < GetMusicTime() + 0.4f &&
           lineObj.GetComponentInChildren<NoteControlor>().timing + timeOffset > GetMusicTime() - 0.4f)
        {
            return "Parfect";
        }
        else if (lineObj.GetComponentInChildren<NoteControlor>().timing + timeOffset < GetMusicTime() - 0.6f)
        {
            return "Miss";
        }
        else
        {
            return default;
        }
    }

    void ComboCount()
    {

    }

    void SpawnNotes(int num)
    {
        var obj = Instantiate(notes[num],new Vector3(-4.0f + (2.0f * num), 5f, 0), Quaternion.identity);
        obj.name = "Note"+ _SpawndNotesCount ;
        obj.transform.parent = NoteLine[num].transform;
        obj.GetComponent<NoteControlor>().timing = _timing[_SpawndNotesCount];
    }

    void LoadCSV()
    {

        TextAsset csv = Resources.Load(GamePlayManager.instance.passName) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {
            
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
        maxCombo = i;
    }

    private void InstanceTiming(int hs)
    {
        //hs10 = timing-0.4f
        //hs5 = timing-1.5f
        switch (hs)
        {
            case 5:
                timing = -1.5f;
                break;
            case 6:
                timing = -1.05f;
                break;
            case 7:
                timing = -0.8f;
                break;
            case 8:
                timing = -0.65f;
                break;
            case 9:
                timing = -0.5f;
                break;
            case 10:
                timing = -1.2f;
                break;
        }
    }

    float GetMusicTime()
    {
        return Time.time - _startTime;
    }

    IEnumerator ReadyGo()
    {
        _UIManager.StartTextChange("Ready...");
        yield return new WaitForSeconds(2);
        _UIManager.StartTextChange("GO!!");
        yield return new WaitForSeconds(1);
        _UIManager.StartTextChange("");
        StartGame();
    }
}
