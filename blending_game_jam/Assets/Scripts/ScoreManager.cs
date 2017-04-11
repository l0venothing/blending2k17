using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    private int victimNumber;
	// Use this for initialization
	void Start () {
        victimNumber = PlayerPrefs.GetInt("score");
        scoreText.text = "You killed : " + victimNumber + " Monsters";
    }
    
    
    void Update () {
      
		
	}
}
