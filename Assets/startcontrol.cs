using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcontrol : MonoBehaviour {
    public float rotdegree;
    public aa1 a1;
    public aa2 a2;
    public aa3 a3;
	// Use this for initialization
	void Start () {
        a1 = GameObject.FindGameObjectWithTag("alien1").GetComponent<aa1>();
        a2 = GameObject.FindGameObjectWithTag("alien2").GetComponent<aa2>();
        a3 = GameObject.FindGameObjectWithTag("alien3").GetComponent<aa3>();
        rotdegree = 60.0f;
    }
	
	// Update is called once per frame
	void Update () {
 
        a1.gameObject.transform.Rotate(rotdegree *new Vector3(0,-1,0)* Time.deltaTime,Space.Self);
        a2.gameObject.transform.Rotate(rotdegree * new Vector3(0, -1, 0) * Time.deltaTime, Space.Self);
        a3.gameObject.transform.Rotate(rotdegree * new Vector3(0, -1, 0) * Time.deltaTime, Space.Self);
    }
}
