using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float screenWidth;
    bool jump = false;
    float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetFloat("Speed", 0.08f); //il player inizia con animazione Run_02
        screenWidth = Screen.width;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
                Touch touch = Input.GetTouch(0);
                jump = true;
                animator.SetBool("isJumping", true);
        }
    }

    //Move our character
    void FixedUpdate()
    {
        controller.Move(0,false,jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetFloat("Speed", speed);
    }
}
