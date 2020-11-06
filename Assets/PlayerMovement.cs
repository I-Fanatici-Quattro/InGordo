using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float screenWidth;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
       // animator.SetFloat("Speed", 0.2);
        screenWidth = Screen.width;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            jump = true;
        }
        
    }

    //Move our character
    void FixedUpdate()
    {
        controller.Move(0,false,jump);
        jump = false;
    }
}
