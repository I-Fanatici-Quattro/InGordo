using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavimento : MonoBehaviour
{


    [SerializeField]
    int velocitaTerreno=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3 (velocitaTerreno*Time.deltaTime,0,0);
        if(transform.position.x <= -37.71)
        {
            transform.position =new Vector3(37.71f,transform.position.y,0f );
        }
    }
}
