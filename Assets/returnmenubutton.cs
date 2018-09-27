using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnmenubutton : MonoBehaviour {

    // Use this for initialization
    public void returngame()
    {
        SceneManager.LoadScene("start");
    }
}
