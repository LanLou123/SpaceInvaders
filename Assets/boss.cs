using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class boss : MonoBehaviour {

	// Use this for initialization
    public float stage1shootinterval;
    public float stage2shootinterval;
    public GameObject stag1bullet;
    public GameObject stag2bullet;
    public float stage1rot2;
    public float stage1timer2;
    public float stg2rot2;
    public float stg2cnt2; 
    public float stage1rot;
    public float stage1timer;
    public float rotdegree;
    public bool functional;
    public float stg2rot;
    public float stg2timer;
    public float stg2timer2;
    public int stg2cnt;
	void Start () {
        stage1shootinterval = 1;
        stage2shootinterval = 0.05f;
       rotdegree =( 2 * Mathf.PI) / 20;
        stage1timer = 0;
        stage1rot = 0;
        functional = false;
        stg2cnt = 0;
        stg2rot = 0;
        stage1rot2 = 0;
        stage1timer2 = 0;
        stg2timer = 0;
        stg2cnt2 = 0;
        stg2rot2 = 0;
        stg2timer2 = 0;

	}

    void checklife()
    {
        Global gbs = GameObject.FindGameObjectWithTag("FGlobal").GetComponent<Global>();
        if (gbs.bosslives > 12)
        {
            firestage1();
        }
        else if(gbs.bosslives>8&&gbs.bosslives<=12)
        {
            firestage2();
        }
        else if(gbs.bosslives<=8&&gbs.bosslives>0)
        {
            firestage3();
        }
        else if(gbs.bosslives<=0)
        {
            PlayerScore pps = GameObject.FindGameObjectWithTag("playerscore").GetComponent<PlayerScore>();
            pps.ScopeScore += 300;
            SceneManager.LoadScene("win");
            Destroy(gameObject);
            
        }
    }
    public void  firestage1()
    {
        stage1timer += Time.deltaTime;
        if (stage1timer > stage1shootinterval)
        {
            stage1timer = 0;
            Vector3 spanwpos =new Vector3( -1, gameObject.transform.position.y,10f);
            for (stage1rot = 0; stage1rot < 2 * Mathf.PI; stage1rot += rotdegree)
            {
                spanwpos.x += 1.70f * Mathf.Cos(stage1rot);
                spanwpos.z -= 1.70f * Mathf.Sin(stage1rot);
                GameObject obj = Instantiate(stag1bullet, spanwpos, Quaternion.identity) as GameObject;
                ene2bullet bb = obj.GetComponent<ene2bullet>();
                bb.thrust = new Vector3(0, 0, 300);
                Quaternion rot = Quaternion.Euler(new Vector3(0, stage1rot * 180 / Mathf.PI, 0));
                
                bb.GetComponent<Rigidbody>().MoveRotation(rot);
            }
        }
    }
    public void firestage2()
    {
        stg2timer += Time.deltaTime;
        if (stg2timer > stage2shootinterval)
        {
            stg2timer = 0;
            Vector3 spanwpos = new Vector3(-1, gameObject.transform.position.y, gameObject.transform.position.z);

                if(stg2cnt>=20)
            {
                stg2cnt = 0;
            }
            stg2rot = stg2cnt * rotdegree;
                spanwpos.x += 4f * Mathf.Cos(stg2cnt);
                spanwpos.z -= 4f * Mathf.Sin(stg2cnt);
                GameObject obj = Instantiate(stag2bullet, spanwpos, Quaternion.identity) as GameObject;
                ene2bullet bb = obj.GetComponent<ene2bullet>();
                bb.thrust = new Vector3(0, 0, 300);
                Quaternion rot = Quaternion.Euler(new Vector3(0, stg2cnt * 180 / Mathf.PI, 0));

                bb.GetComponent<Rigidbody>().MoveRotation(rot);
            stg2cnt++;
        }
    }
    public void firestage12()
    {
        stage1timer2 += Time.deltaTime;
        if (stage1timer2 > stage1shootinterval)
        {
            stage1timer2 = 0;
            Vector3 spanwpos = new Vector3(-1, gameObject.transform.position.y, 10f);
            for (stage1rot2 = 0; stage1rot2 < 2 * Mathf.PI; stage1rot2 += rotdegree)
            {
                spanwpos.x += 1.70f * Mathf.Cos(stage1rot2);
                spanwpos.z -= 1.70f * Mathf.Sin(stage1rot2);
                GameObject obj = Instantiate(stag1bullet, spanwpos, Quaternion.identity) as GameObject;
                ene2bullet bb = obj.GetComponent<ene2bullet>();
                bb.thrust = new Vector3(0, 0, 300);
                Quaternion rot = Quaternion.Euler(new Vector3(0, stage1rot2 * 180 / Mathf.PI, 0));

                bb.GetComponent<Rigidbody>().MoveRotation(rot);
            }
        }
    }
    public void firestage22()
    {
        stg2timer2 += Time.deltaTime;
        if (stg2timer2 > stage2shootinterval)
        {
            stg2timer2 = 0;
            Vector3 spanwpos = new Vector3(-1, gameObject.transform.position.y, gameObject.transform.position.z);

            if (stg2cnt2 >= 20)
            {
                stg2cnt2 = 0;
            }
            stg2rot2 = stg2cnt2 * rotdegree;
            spanwpos.x += 4f * Mathf.Cos(stg2cnt2);
            spanwpos.z -= 4f * Mathf.Sin(stg2cnt2);
            GameObject obj = Instantiate(stag2bullet, spanwpos, Quaternion.identity) as GameObject;
            ene2bullet bb = obj.GetComponent<ene2bullet>();
            bb.thrust = new Vector3(0, 0, 300);
            Quaternion rot = Quaternion.Euler(new Vector3(0, stg2cnt2 * 180 / Mathf.PI, 0));

            bb.GetComponent<Rigidbody>().MoveRotation(rot);
            stg2cnt2++;
        }
    }
    public void firestage3()
    {
        firestage12();
        firestage22();
    }
    public void hit()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (functional)
        {
            checklife();
        }
	}
}
