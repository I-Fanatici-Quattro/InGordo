using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMove : MonoBehaviour
{
    public GameObject Spawn;
    public GameObject Cac;
    [SerializeField]
    int ritardoPrimaApparizione =0;
    [SerializeField]
    float tempoDiApparizione=2.0f;

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating ("a",ritardoPrimaApparizione,tempoDiApparizione);              
    }

    void Update()
    { 

    }


    void a()
    {
        Spawn = Instantiate (Cac,transform.position,Quaternion.identity)as GameObject; 
    }
}
