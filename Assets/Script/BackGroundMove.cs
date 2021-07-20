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
        transform.position -= new Vector3 (velocitaTerreno*Time.deltaTime,0,0);
        if(transform.position.x <= -21.49)
        {
            transform.position =new Vector3(21.49f,transform.position.y,3);
        }
    }
}
