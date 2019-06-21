using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    List<int> game = new List<int>();
	// Use this for initialization
	void Start () {
        game.Add(1);
        game.Add(2);
        game.Add(3);
        Debug.Log(game.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
