﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Pavimento3 : MonoBehaviour
{
    public int velocitaTerreno = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3 (velocitaTerreno*Time.deltaTime,0,0);
        if(transform.position.x <= -3.32)
        {
            transform.position =new Vector3(48.33f,transform.position.y,0f);
        }
    }
}
