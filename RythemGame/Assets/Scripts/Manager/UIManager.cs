using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] Text _comboText;
    [SerializeField] Slider _ScoreSlider;
    [SerializeField] Text StartText;
    [SerializeField] Text hantei;
    [SerializeField] Image back;
    [SerializeField] Text scoreText;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

    }
    public void ComboCount(int num)
    {
        _comboText.text = num.ToString();
    }
    public void ScoreUp(int score)
    {
        _ScoreSlider.value = score;
        scoreText.text = score.ToString();

    }
    public void StartTextChange(string str)
    {
        StartText.text = str;
    }

    public void Hantei(string str)
    {
        hantei.text = str;
    }

    public void Back(Sprite sprite)
    {
        back.sprite = sprite;
    }
    
}
