using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life1 : MonoBehaviour {

    public int scopelife;
    RawImage raw1;
	// Use this for initialization
	void Start () {
        scopelife = 1;
        raw1 = gameObject.GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(scopelife==0)
        {
           raw1.color = Color.red;
        }
	}
}
