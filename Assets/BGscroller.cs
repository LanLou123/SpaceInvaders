using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour {
    public float scorllSpeed;
    public float timeSizez;
    private Vector3 startpos;
	// Use this for initialization
	void Start () {
        scorllSpeed = -0.9f;
        timeSizez = 108.7547f;
        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newpos = Mathf.Repeat(Time.time * scorllSpeed,timeSizez);
        transform.position = startpos + Vector3.forward * newpos;
	}
}
