using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timerPunteggio : MonoBehaviour
{
    public static float t=5f;
    public  Score s;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        t -=Time.deltaTime;
        if(t<0 && other.gameObject.tag=="floor"){
        t=0;
        s.score++;
        s.currentscore.text =s.score.ToString();
        }
    } 
}
