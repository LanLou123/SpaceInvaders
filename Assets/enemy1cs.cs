using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy1cs : MonoBehaviour {
    public GameObject eneBullet1;
    public GameObject explosion;
    public AudioClip deathclip;
    public AudioClip enemyshoot;
    public float g;
    public bool fall;
	// Use this for initialization
	void Start () {
        g = -9.8f;
        fall = false;
        GameObject[] collidertoignore = GameObject.FindGameObjectsWithTag("Penemy1");
        GameObject[] collidertoignore1 = GameObject.FindGameObjectsWithTag("Penemy2");
        GameObject[] collidertoignore2 = GameObject.FindGameObjectsWithTag("Penemy3");
        foreach (GameObject gg in collidertoignore)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (GameObject gg in collidertoignore1)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (GameObject gg in collidertoignore2)
            Physics.IgnoreCollision(gg.GetComponent<Collider>(), GetComponent<Collider>());
    }
    
    public void Die()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        //player testP = GameObject.FindGameObjectWithTag("Fplayer").GetComponent<player>();
        //testP.Die();
        AudioSource.PlayClipAtPoint(deathclip, gameObject.transform.position);
        Global Pg = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        Pg.PlayerScoreGlobal += 10;
        PlayerScore pps = GameObject.Find("PlayerScore").GetComponent<PlayerScore>();
        if(gameObject.name != "destroyed")
        pps.ScopeScore += 10;
        gameObject.name = "destroyed";
        fall = true;

        //Destroy(gameObject);

    }

    public void Fire()
    {
        AudioSource.PlayClipAtPoint(enemyshoot, gameObject.transform.position);
        Vector3 spawnpos = gameObject.transform.position;
        spawnpos.z -= 1.5f;
        GameObject obj = Instantiate(eneBullet1, spawnpos, Quaternion.identity) as GameObject;
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void FixedUpdate()
    {
        if (!fall)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        if (fall)
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -9));
        }
    }
    // Update is called once per frame
    void Update () {
        if (fall)
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -9));
        }
        if (!fall)
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
