using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPlayer : MonoBehaviour
{
    [SerializeField]
    int salto=4;
    public bool IJ;
    // Start is called before the first frame update
    void Start()
    {
       IJ=false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && IJ==false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,salto,0);
            IJ=true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag=="Finish")
        {
            IJ=false;
        }

        if(coll.gameObject.tag=="Respawn")
        {
            Application.LoadLevel ("provaMia");
        }
    }
}
