using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour {

    // Use this for initialization

        public float timeLeft;
        void Start()
        {
            timeLeft = 1.0f;
        }
        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    
}
