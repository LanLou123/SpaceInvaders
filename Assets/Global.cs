using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {

    public int bosslives;
    public float timer;
    public int PlayerScoreGlobal;
    public int playerlifeGlobal;
    public int playerhighscore;
    float playerspecialgunlasttime;
    public float gunstyletimer;
    public int playergunstyle;
	// Use this for initialization
    
	void Start () {
        DontDestroyOnLoad(this);
        timer = 0.0f;
        bosslives = 18;
        playerhighscore=0;
        PlayerScoreGlobal = 0;
        playerlifeGlobal = 3;
        playergunstyle = 1;
        playerspecialgunlasttime = 10;
        gunstyletimer = 0;
	}

    // Update is called once per frame


    void Update () {
        playerhighscore = playerhighscore < PlayerScoreGlobal ? PlayerScoreGlobal : playerhighscore;
        timer += Time.deltaTime;
        gunstyletimer += Time.deltaTime;
        if(gunstyletimer>=playerspecialgunlasttime)
        {
            gunstyletimer = 0;
            if (playergunstyle > 1) playergunstyle--;
        }
	}
}
