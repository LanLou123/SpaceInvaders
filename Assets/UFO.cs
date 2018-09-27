using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    public GameObject explosion;
    public AudioClip death;
    public Vector3 thrust;
    public float ufotimer;
    public float ufofiretime;
    public GameObject fireball;
    bool isfired = false;
	// Use this for initialization
	void Start () {
        thrust.x = 20400;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
        ufotimer = 0;
        ufofiretime = 2.0f;
    }
	
    public void Die()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(death, gameObject.transform.position, 4);
        PlayerScore ng = GameObject.FindGameObjectWithTag("playerscore").GetComponent<PlayerScore>();
        ng.ScopeScore += 100;
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
        ufotimer += Time.deltaTime;
        if(ufotimer>ufofiretime&&isfired==false)
        {
            Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
            isfired = true;
        }
		if(gameObject.transform.position.x>30)
        { Destroy(gameObject); }
	}
}
