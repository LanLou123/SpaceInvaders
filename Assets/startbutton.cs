using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour {

	// Use this for initialization
public void startgame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void exit()
    {
        Application.Quit();
    }
}
