using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Pavimento : MonoBehaviour
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
        if(transform.position.x <= -17.69)
        {
            transform.position =new Vector3(17.69f,transform.position.y,0f );
        }
    }
}
