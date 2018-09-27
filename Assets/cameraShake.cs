using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    public float power = 4.7f;
    public float duration = 0.5f;
    public Transform camera;
    public float slowdownamount = 6f;
    public bool shouldShake = false;

    Vector3 startPos;
    float initialDuration;
	// Use this for initialization
	void Start () {
        camera = Camera.main.transform;
        startPos = camera.localPosition;
        initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldShake)
        {
            if(duration>0)
            {
                camera.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowdownamount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPos;
            }
        }
	}
}
