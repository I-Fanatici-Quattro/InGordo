using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float speed=10f;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
      body=GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
     Movement();
    // Aiming();   
    }

   

    void Movement()
    {
        float h=Input.GetAxisRaw("Horizontal");
        float v=Input.GetAxisRaw("Vertical");

        Vector2 movement=new Vector2(h,v);

        body.MovePosition(body.position + movement.normalized*Time.deltaTime*speed);
    }
}
