using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public Vector3 thrust;
    // Use this for initialization
    void Start () {
        Debug.Log("special enemy fire!");
        thrust.z = -15000.0f;
        thrust.x = 15000.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
        GameObject[] collidertoignore = GameObject.FindGameObjectsWithTag("Penemy1");
        GameObject[] collidertoignore1 = GameObject.FindGameObjectsWithTag("Penemy2");
        GameObject[] collidertoignore2 = GameObject.FindGameObjectsWithTag("Penemy3");
        foreach (GameObject gg in collidertoignore)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (GameObject gg in collidertoignore1)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (GameObject gg in collidertoignore2)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        GameObject other = GameObject.FindGameObjectWithTag("UFO");
        Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
        GameObject[] collider3 = GameObject.FindGameObjectsWithTag("bunker");
        foreach (GameObject gg in collider3)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        GameObject other1 = GameObject.FindGameObjectWithTag("plane");
        Physics.IgnoreCollision(other1.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
    public void Die()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Fplayer"))
        {
            Global ng = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
            ng.playergunstyle++;
            ng.gunstyletimer = 0;
            Destroy(gameObject);
        }
    }
        // Update is called once per frame
        void Update () {
		
	}
}
