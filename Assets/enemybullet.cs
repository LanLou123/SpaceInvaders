using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour {
    public Vector3 thrust;
    public Quaternion heading;
    // Use this for initialization
    void Start () {
        Debug.Log("enemy fire!");
        thrust.z = -1200.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Fplayer"))
        {
            player e1 = collider.gameObject.GetComponent<player>();
            e1.Die();
            Destroy(gameObject);
        }
        if(collider.CompareTag("bunker"))
        {
            bunker eb = collider.gameObject.gameObject.GetComponent<bunker>();
            eb.Die();
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
    }
        // Update is called once per frame
        void Update () {
		if(gameObject.transform.position.z<-20)
        {
            Destroy(gameObject);
        }
	}
}
