//#define MOVESTYLE1
#define MOVESTYLE2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {
    public float constSpeed;
    public float speed;
    public float acc;
    public float damping;
    public float playertime;
    public GameObject explosion;
    public AudioClip shootaudio;
    public AudioClip deathclip;
    // Use this for initialization
    void Start () {
        Global gb = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        gb.playerlifeGlobal = 3;
        gb.PlayerScoreGlobal = 0;
        constSpeed = 0.1f;
        speed = 0.0f;
        acc = 0.01f;
        damping = 0.005f;
        playertime = 0; 
	}
	void FixedUpdate()
    {

#if(MOVESTYLE1)
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            speed += acc;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            speed -= acc;
           
        }
        gameObject.transform.Translate(speed, 0, 0);
        speed = speed > 0 ? speed - damping : speed + damping;
        if(Input.GetAxisRaw("Horizontal")==0)
        {
            if (Mathf.Abs(speed) < 0.005) speed = 0;
        }
        if (gameObject.transform.position.x < -10 || gameObject.transform.position.x > 10)
        {
            if (gameObject.transform.position.x < -10) gameObject.transform.Translate(-gameObject.transform.position.x - 10, 0, 0);
            if (gameObject.transform.position.x > 10) gameObject.transform.Translate(-gameObject.transform.position.x + 10, 0, 0);
            speed = 0;
        }
#endif
#if (MOVESTYLE2)
          if (Input.GetAxisRaw("Horizontal") > 0)
        {
             gameObject.transform.Translate(constSpeed, 0, 0,Space.World);
            
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 150);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.Translate(-constSpeed, 0, 0,Space.World);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
#endif

    }
    public GameObject bullet;
    // Update is called once per frame
    public IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("gameover");
    }
    public void Die()
    {
        Global pg = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        if (pg.playerlifeGlobal == 3)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathclip, gameObject.transform.position,20);
            RawImage pi = GameObject.FindGameObjectWithTag("lifeimg1").GetComponent<RawImage>();
            pi.color = Color.red;
            pg.playerlifeGlobal--;
            gameObject.transform.transform.position = new Vector3(0, 0, -13.2f);
            cameraShake cs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShake>();
            cs.shouldShake = true;
        }
        else if(pg.playerlifeGlobal==2)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            
            AudioSource.PlayClipAtPoint(deathclip, gameObject.transform.position,20);
            RawImage pi = GameObject.FindGameObjectWithTag("lifeimg2").GetComponent<RawImage>();
            pi.color = Color.red;
            pg.playerlifeGlobal--;
            gameObject.transform.transform.position = new Vector3(0, 0, -13.2f);
            cameraShake cs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShake>();
            cs.shouldShake = true;

        }
        else if(pg.playerlifeGlobal==1)
        {
            playertime = 0;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathclip, gameObject.transform.position,20);
            RawImage pi = GameObject.FindGameObjectWithTag("lifeimg3").GetComponent<RawImage>();
            pi.color = Color.red;
            pg.playerlifeGlobal--;
            cameraShake cs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShake>();
            cs.shouldShake = true;
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            jetsrc sss = GameObject.FindGameObjectWithTag("playerengine").GetComponent<jetsrc>();
            sss.Die();
            StartCoroutine(LoadLevelAfterDelay(1.0f));
            //SceneManager.LoadScene("gameover");

        }
    }
	void Update () {
        playertime += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(shootaudio, gameObject.transform.position);
            Vector3 spawnpos = gameObject.transform.position;
            spawnpos.z += 1.5f;
            GameObject obj = Instantiate(bullet, spawnpos, Quaternion.identity) as GameObject;
            Global ng = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
            if (ng.playergunstyle > 1)
            {
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = new Vector3(0, -5, 0);
                GameObject obj1 = Instantiate(bullet, new Vector3(spawnpos.x-1.5f,spawnpos.y,spawnpos.z),rot) as GameObject;
                obj1.GetComponent<Bullet>().thrust.x = -100;
                rot.eulerAngles = new Vector3(0, 5, 0);
                GameObject obj2 = Instantiate(bullet, new Vector3(spawnpos.x + 1.5f, spawnpos.y, spawnpos.z),rot) as GameObject;
                obj2.GetComponent<Bullet>().thrust.x = 100;
            }
        }
	}
}
