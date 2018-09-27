using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3cs : MonoBehaviour {
    public GameObject eneBullet1;
    public GameObject explosion;
    public AudioClip deathclip;
    public AudioClip enemyshoot;
    public bool fall;
    // Use this for initialization
    void Start () {
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
        AudioSource.PlayClipAtPoint(deathclip, gameObject.transform.position);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Global Pg = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        Pg.PlayerScoreGlobal += 30;
        PlayerScore pps = GameObject.Find("PlayerScore").GetComponent<PlayerScore>();
        if (gameObject.name != "destroyed")
            pps.ScopeScore += 30;
        gameObject.name = "destroyed";
        fall = true;
        //Destroy(gameObject);
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
