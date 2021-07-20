using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreScenaDue : MonoBehaviour
{
    //GameObject obj;
    public Pavimento3 pav;
    public Pavimento3 pav2;

    //Punteggio chilometri
    [SerializeField]
    //public Text PuntiText;

    public Text currentscore;
    public Text highScore;
    public int score = 0;

    //vita Personaggio

    //public GameObject image;
    float maxhealth=100;

    float health;

    Image healthBar;
    float barWidth,barHeight;
    float healtCurrent;

    //punteggio
    public int punti=0;
    public Text ScoreText;
    

    /*void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("floor");
    }*/
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("BestScore", 0);
        //highScore.text = PlayerPrefs.GetInt("BestScore").ToString();

        healthBar= GameObject.FindGameObjectWithTag("barraVita").GetComponent<Image>();
        health=maxhealth;

        barWidth=healthBar.rectTransform.sizeDelta.x;
        barHeight= healthBar.rectTransform.sizeDelta.y;
        
    }

    // Update is called once per frame
    void Update()
    {

         //obj.GetComponent<Pavimento>().velocitaTerreno +=10;
        score++;
        currentscore.text =score.ToString();
        
        /*if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            highScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.tag=="good")
        {
            AddScore();
        }

        if (other.gameObject.tag =="bad")
        {
            if(punti>=1)
            {
                DelScore();
                DelVita();
            }
            else
            {
                DelVita();
            } 
        }
    }

    void AddScore()
    {
        if(health>0 && health!=100){
            health +=2;
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);
        }
        punti++;
        ScoreText.text= punti.ToString();
    }

    void DelScore()
    {
        punti--;
        ScoreText.text=punti.ToString();
    }

    void DelVita()
    {
        float damage=5;
        health -=damage;

        if(health>40){
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);
        }

        if(health>25 && health<=65){
            healthBar.GetComponent<Image>().color = new Color32(255,128,0,255);
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);

        }

        if(health>0 && health<=25){
            healthBar.GetComponent<Image>().color = new Color32(255,0,0,255);
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);

        }

        if(health==0)
        {
            Application.LoadLevel ("InGordo2");
        }
    }
}