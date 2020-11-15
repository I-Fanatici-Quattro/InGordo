using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class Disable : MonoBehaviour
{

    public Button mybutton;
    public Sprite audioongrande;
    public Sprite audiooffgrande;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        mybutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeButton()
    {
        counter++;
        if (counter % 2 == 0)
        {
            mybutton.image.overrideSprite = audioongrande;
        }
        else
        {
            mybutton.image.overrideSprite = audiooffgrande;
        }
    }
}
