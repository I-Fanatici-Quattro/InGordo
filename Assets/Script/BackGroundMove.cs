using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BackGroundMove : MonoBehaviour
{
    public int velocitaTerreno = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3 (velocitaTerreno*Time.deltaTime,0,-1.2f);
        if(transform.position.x <= -22.21)
        {
            transform.position =new Vector3(22.21f,transform.position.y,-1.2f);
        }
    }
}
