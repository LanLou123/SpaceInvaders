using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public int ScopeScore;
    public Text score;
    Global obj;
    // Use this for initialization
    void Start () {
        ScopeScore = 0;
        score = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        score.text = "Player Score : " + ScopeScore.ToString();
        Global ng = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        ng.PlayerScoreGlobal = ScopeScore;
    }
}
