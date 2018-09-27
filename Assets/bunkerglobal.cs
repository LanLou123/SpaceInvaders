using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunkerglobal : MonoBehaviour {

    public int bunkerwidth;
    public int bunkerhight;
    public float bunkerspacing;
    public float bunkergroupspacing;
    public GameObject onebunker;
    public Vector3 bunkertoppos;
	// Use this for initialization
	void Start () {
        bunkerwidth = 8;
        bunkerhight = 6;
        bunkerspacing = 0.3f;
        bunkergroupspacing = 6.0f;
        Vector3 initialpos = new Vector3(-18, 0, -10);
        float onebunkerwidthreal = bunkerwidth * (bunkerspacing + 0.3f) - bunkerspacing;
        for(int i=0;i<4;++i)
        {
            Vector3 Pose = initialpos+new Vector3(i*(onebunkerwidthreal+bunkergroupspacing),0,0);
            for(int j=0; j<bunkerwidth;++j)
            {
                for(int k=0;k<bunkerhight;++k)
                {
                    Vector3 newpos = new Vector3(j * bunkerspacing, 0, k * bunkerspacing) + Pose;
                    Instantiate(onebunker, newpos, Quaternion.identity);
                }
            }
        }
        bunkertoppos = new Vector3(0, 0, bunkerhight * (bunkerspacing + 0.3f) - bunkerspacing)+initialpos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
