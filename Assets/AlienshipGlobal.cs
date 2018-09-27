using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AlienshipGlobal : MonoBehaviour {
    public int numAlienRow;
    public int alienSpaceing;
    public int enemywidth;
    public int fighter;
    Global CurGlobalObj;
    public List<List<int>> checker;
    public List<List<GameObject>> AllAlienShiparr;
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    public GameObject UFOship;
    public List<GameObject> Alienarr1;
    public List<GameObject> Alienarr2;
    public List<GameObject> Alienarr21;
    public List<GameObject> Alienarr3;
    public List<GameObject> Alienarr31;
    public GameObject OneAlien;
    public float AlienTimer;
    public float AlienShootTimer;
    public float AlienShootSpeed;
    public float AlienSpeed;
    public int moveVcount;
    public int moveHcount;
    public int lowestcol;
    public Vector3 curlowpos;
    public bool live;
    public int laststepv;
    public bool nextv;
    public int movehsteps;
    public float UFOtimer;
    public float UFOperiod;
    public Vector3 bossinitialvel;
    public Vector3 bossvelchange;
    public float tmpvel = -1;
    void InstantiateAlien(ref List<GameObject> ShipArr, Vector3 centPos, int p, int type)
    {
        for (int i = 0; i < numAlienRow; ++i)
        {
            float x_pos = centPos.x-(alienSpaceing*numAlienRow/2)+alienSpaceing*i;
            float z_pos = centPos.z;
            Vector3 originPos = new Vector3(x_pos, 0, z_pos);
            switch (type)
            {
                case 1:
                    OneAlien = Instantiate(Alien1,originPos,Quaternion.identity);
                    Alienarr1.Add(OneAlien);
                    break;
                case 2:
                    OneAlien = Instantiate(Alien2, originPos, Quaternion.identity);
                    Alienarr2.Add(OneAlien);
                    break;
                case 21:
                    OneAlien = Instantiate(Alien2, originPos, Quaternion.identity);
                    Alienarr21.Add(OneAlien);
                    break;
                case 3:
                    OneAlien = Instantiate(Alien3, originPos, Quaternion.identity);
                    Alienarr3.Add(OneAlien);
                    break;
                case 31:
                    OneAlien = Instantiate(Alien3, originPos, Quaternion.identity);
                    Alienarr31.Add(OneAlien);
                    break;
            }
        }

    }
    void initializeChecker()
    {
        checker = new List<List<int>>();
        for(int i=0;i< AllAlienShiparr.Count;++i)
        {
            List<int> temp =new List<int>();
            for(int j=0;j<AllAlienShiparr[i].Count;++j)
            {
                temp.Add(1);
            }
            checker.Add(temp);
        }
    }
    void updatePos(Vector2 dis, int col,int row, ref int deathcount)
    {
        if(AllAlienShiparr[row][col]==null|| AllAlienShiparr[row][col].name == "destroyed")
        {
            checker[row][col] = -1;
        }
        if (AllAlienShiparr[row][col] != null&& AllAlienShiparr[row][col].name != "destroyed")
        {
            enemy1cs a = AllAlienShiparr[row][col].GetComponent<enemy1cs>();
            enemy2cs b = AllAlienShiparr[row][col].GetComponent<enemy2cs>();
            enemy3cs c = AllAlienShiparr[row][col].GetComponent<enemy3cs>();
            if (a != null)
            {
                a.gameObject.transform.Translate(new Vector3(dis.x, 0, dis.y));
            }
            if (b != null)
            {
                b.gameObject.transform.Translate(new Vector3(dis.x, 0, dis.y));
            }
            if (c != null)
            {
                c.gameObject.transform.Translate(new Vector3(dis.x, 0, dis.y));
            }
        }
    }
	// Use this for initialization
	void Start () {
        curlowpos = new Vector3(0, 0, 2);
        UFOtimer = 0;
        UFOperiod = 18;
        laststepv = 0;
        movehsteps = 10;
        nextv = false;
        live = true;
        enemywidth = 1;
        lowestcol = 0;
        moveVcount = 0;
        moveHcount = 0;
        AlienTimer = 0;
        AlienShootTimer = 0;
        AlienShootSpeed = 2.0f;
        AlienSpeed = 2.5f;
        numAlienRow = 8;
        alienSpaceing = 2;
        bossinitialvel = new Vector3(0, -10, 0);
        bossvelchange = new Vector3(0, 1, 0);
        InstantiateAlien(ref Alienarr1, new Vector3(10, 0,  2), 10, 1);
        InstantiateAlien(ref Alienarr2, new Vector3(10, 0,  4), 10, 2);
        InstantiateAlien(ref Alienarr21, new Vector3(10, 0, 6), 10, 21);
        InstantiateAlien(ref Alienarr3, new Vector3(10, 0,  8), 10, 3);
        InstantiateAlien(ref Alienarr31, new Vector3(10, 0, 10), 10, 31);
        AllAlienShiparr = new List<List<GameObject>>();
        AllAlienShiparr.Add(Alienarr1);
        AllAlienShiparr.Add(Alienarr2);
        AllAlienShiparr.Add(Alienarr21);
        AllAlienShiparr.Add(Alienarr3);
        AllAlienShiparr.Add(Alienarr31);
        initializeChecker();
        //destroyall();

    }
    public List<int> validenemy;
    void alienFireRand()
    {
        validenemy= new List<int>();
        validenemy.Clear();
        for(int i=0;i< AllAlienShiparr.Count; ++i)
        {
            bool rowlife = false;
            for(int j=0;j<AllAlienShiparr[i].Count;++j)
            {

                if (/*AllAlienShiparr[i][j]!=null||*/ AllAlienShiparr[i][j].name!="destroyed") rowlife = true;
                //only those labled with 2 has the right to fight
                if(i==0&&(checker[i][j]==1||checker[i][j]==2))
                {
                    checker[i][j] = 2;
                    validenemy.Add(i * AllAlienShiparr[i].Count + j);
                }
                else if((i>0)&&(checker[i][j] == 1 || checker[i][j] == 2) && checker[i-1][j]==-1)
                {
                    checker[i][j] = 2;
                    validenemy.Add(i * AllAlienShiparr[i].Count + j);
                }
            }
            if (rowlife == false) lowestcol = i + 1;
            
        }
        fighter=Random.Range(0, validenemy.Count);
        int reali = validenemy[fighter] / numAlienRow;
        int realj = validenemy[fighter] - reali * numAlienRow;
        Debug.Log("reali" + reali + "  realj" + realj);
        if (AllAlienShiparr[reali][realj] != null&& AllAlienShiparr[reali][realj].name != "destroyed")
        {
            enemy1cs a = AllAlienShiparr[reali][realj].GetComponent<enemy1cs>();
            enemy2cs b = AllAlienShiparr[reali][realj].GetComponent<enemy2cs>();
            enemy3cs c = AllAlienShiparr[reali][realj].GetComponent<enemy3cs>();
            if (a != null)
            {
                a.Fire();
                return;
            }
            if (b != null)
            {
                b.Fire();
                return;
            }
            if (c != null)
            {
                c.Fire();
                return;
            }
        }
        
    }
    bool Alienchecklife()
    {
        bool remainlife = false;
        for (int i = 0; i < AllAlienShiparr.Count; ++i)
        {
            for (int j = 0; j < AllAlienShiparr[i].Count; ++j)
            {
                if (AllAlienShiparr[i][j] != null&& AllAlienShiparr[i][j].name != "destroyed")
                    remainlife = true;
            }
        }
        return remainlife;
    }
    void destroyall()
    {
        for (int i = 0; i < AllAlienShiparr.Count; ++i)
        {
            for (int j = 0; j < AllAlienShiparr[i].Count; ++j)
            {

                enemy1cs a = AllAlienShiparr[i][j].GetComponent<enemy1cs>();
                enemy2cs b = AllAlienShiparr[i][j].GetComponent<enemy2cs>();
                enemy3cs c = AllAlienShiparr[i][j].GetComponent<enemy3cs>();
                if (a != null)
                {
                    a.Die();
                }
                if (b != null)
                {
                    b.Die();
                }
                if (c != null)
                {
                    c.Die();
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {

        live = Alienchecklife();
        if (live==false)
        {
            boss nbs = GameObject.FindGameObjectWithTag("boss").GetComponent<boss>();
            nbs.GetComponent<Rigidbody>().velocity = bossinitialvel;
            nbs.GetComponent<Rigidbody>().velocity += bossvelchange;
            if (nbs.transform.position.y <= 0 && nbs.GetComponent<Rigidbody>().velocity.y != 0)

            {
                nbs.transform.position = new Vector3(nbs.transform.position.x, 0, nbs.transform.position.z);
                nbs.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            }
            if(nbs.transform.position.y==0)
            {
                nbs.functional = true;
            }
            if(nbs.functional==true)
            {
                //if(nbs.transform.position.y>-1&& nbs.transform.position.y<1)
                //nbs.transform.position += tmpvel * Time.deltaTime * new Vector3(0, 1, 0);
                //if (nbs.transform.position.y <= -1|| nbs.transform.position.y>=1)
                //    tmpvel = -tmpvel;

            }

        }
            //SceneManager.LoadScene("win");
        bunkerglobal bgg = GameObject.FindGameObjectWithTag("bunkerglobal").GetComponent<bunkerglobal>();
        float topbunker = bgg.bunkertoppos.z;
        float lowbound = curlowpos.z + lowestcol * (enemywidth + 2);
        if(lowbound<topbunker+1)
        {
            SceneManager.LoadScene("gameover");
            Debug.Log("GAME FINISH");
        }
        if (live)
        {
            
            AlienShootTimer += Time.deltaTime;
            if (AlienShootTimer > AlienShootSpeed)
            {
                alienFireRand();
                AlienShootTimer = 0;
            }
        }
        UFOtimer += Time.deltaTime;
        if(UFOtimer>UFOperiod)
        {
            UFOtimer = 0;
           Instantiate(UFOship, new Vector3(-30, 0, 12), Quaternion.identity);
            UFOship.transform.rotation= (Quaternion.Euler(-90, 90, 90));
        }
        if (live)
        {
            int deathcount = 0;
            AlienTimer += Time.deltaTime;
            if (AlienTimer > AlienSpeed)
            {
                AlienTimer = 0;
                if (nextv == false)
                {
                    if (moveVcount % 2 == 0)
                    {
                        curlowpos += new Vector3(-2, 0, 0);
                        for (int i = 0; i < AllAlienShiparr.Count; ++i)
                        {
                            for (int j = 0; j < AllAlienShiparr[i].Count; ++j)
                            {
                                updatePos(new Vector2(-2, 0), j, i, ref deathcount);

                            }
                        }
                        moveHcount++;
                    }
                    else
                    {
                        curlowpos += new Vector3(2, 0, 0);
                        for (int i = 0; i < AllAlienShiparr.Count; ++i)
                        {
                            for (int j = 0; j < AllAlienShiparr[i].Count; ++j)
                            {
                                updatePos(new Vector2(2, 0), j, i, ref deathcount);

                            }
                        }
                        moveHcount++;
                    }
                }


                if (nextv == true)
                {
                    curlowpos += new Vector3(0, 0, -2);
                    for (int i = 0; i < AllAlienShiparr.Count; ++i)
                    {
                        for (int j = 0; j < AllAlienShiparr[i].Count; ++j)
                        {
                            updatePos(new Vector2(0, -2), j, i, ref deathcount);

                        }
                    }

                    moveVcount++;
                    nextv = false;
                }
                if (moveHcount % movehsteps == 0 && moveVcount == laststepv)
                    nextv = true;
                laststepv = moveVcount;
            }
        }
        


    }
}
