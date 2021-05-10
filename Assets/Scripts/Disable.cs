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
    private bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        mybutton = GetComponent<Button>();
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
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
