using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 thrust;
    public AudioClip hitclipboss;
    public GameObject explosion;
    // Use this for initialization
    void Start () {
        GameObject collidertoignore = GameObject.FindGameObjectWithTag("fireball");
        if(collidertoignore)
        Physics.IgnoreCollision(collidertoignore.GetComponent<Collider>(), GetComponent<Collider>());
        Debug.Log("fire!");
        thrust.z = 1200.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
	}
	
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if(collider.CompareTag("Penemy1"))
        {
            enemy1cs e1 = collider.gameObject.GetComponent<enemy1cs>();
            e1.Die();
            Destroy(gameObject);
        }
        if (collider.CompareTag("Penemy2"))
        {
            enemy2cs e2 = collider.gameObject.GetComponent<enemy2cs>();
            e2.Die();
            Destroy(gameObject);
        }
        if (collider.CompareTag("Penemy3"))
        {
            enemy3cs e3 = collider.gameObject.GetComponent<enemy3cs>();
            e3.Die();
            Destroy(gameObject);
        }
        if(collider.CompareTag("bunker"))
        {
            bunker eb = collider.gameObject.GetComponent<bunker>();
            eb.Die();
            Destroy(gameObject);
        }
        if(collider.CompareTag("UFO"))
        {
            UFO uf = collider.gameObject.GetComponent<UFO>();
            uf.Die();
            Destroy(gameObject);
        }
        if(collider.CompareTag("boss"))
        {
            Global gbs = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
            boss bs = GameObject.FindGameObjectWithTag("boss").GetComponent<boss>();
            AudioSource.PlayClipAtPoint(hitclipboss, bs.transform.position,10);
            Instantiate(explosion, bs.transform.position, Quaternion.identity);
            gbs.bosslives--;
        }
        if(collider.CompareTag("Fplayer"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).z > Screen.height + 50)
        {
            Destroy(gameObject);
        }

    }
}
