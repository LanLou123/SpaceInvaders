using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiscorefail : MonoBehaviour {
    public Text score;
    // Use this for initialization
    void Start () {
        score = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        Global gs = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        score.text = "Player Score :" + gs.PlayerScoreGlobal;
    }
}
