using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    //timer per la vita
    public static float t=5f;//tempo che serve a misurare dopo quanto il conta chilometri si deve aggiornare
    public static float t1=5f;//tempo timer dopo il quale il personaggio perde vita perché non si nutre

    //GameObject obj;
    public Pavimento3 pav;
    public Pavimento3 pav2;

    //Punteggio chilometri
    [SerializeField]
    //public Text PuntiText;

    public Text metri;
    public Text chilometri;
    //public Text highScore;
    public int scoreM = 0;
    public int scoreK = 0;

    //vita Personaggio

    //public GameObject image;
    float maxhealth=100;

    float health;

    Image healthBar;
    float barWidth,barHeight;
    float healtCurrent;

    //punteggio
   // public int punti=0;
   // public Text ScoreText;
    

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
        t -= Time.deltaTime;
        bool v=false;
        while(t<0){
            scoreM++;
            if(scoreM<=9)
            {
                metri.text =scoreM.ToString();
            }
            else
            {
                scoreM=0;
                metri.text =scoreM.ToString();
                scoreK++;
                chilometri.text = scoreK.ToString();

            }
            t=5;
        }

        t1 -=Time.deltaTime;
        while(t1<0){
            DelVita();
            t1=5;
        }
        
        /*if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            highScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        }*/
        if(health==0)
        {
            Application.LoadLevel ("InGordo");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(health>=20){
            if(other.gameObject.tag=="good")
            {
                AddScore(2);
                t1=5;//ogni volta che il personaggio mangia il timer si resetta e torna a 5
            }

            if (other.gameObject.tag =="bad")
            {
                //DelScore();
                DelVita();
                t1=5;//ogni volta che il personaggio mangia il timer si resetta e torna a 5
            }
        }
        else{
           if(other.gameObject.tag =="bad" || other.gameObject.tag=="good"){
                AddScore(2);
                t1=5;//ogni volta che il personaggio mangia il timer si resetta e torna a 5
            }
        }
    }

    void AddScore(int a)
    {
        if(health>0 && health!=100){
            health +=a;
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);
        }
        //punti++;
        //ScoreText.text= punti.ToString();
    }

   /* void DelScore()
    {
        punti--;
        ScoreText.text=punti.ToString();
    }*/

    void DelVita()
    {
        float damage=5;
        health -=damage;
        /*if(health>90 && health<100)
        {
            Application.LoadLevel ("InGordo2");
        }*/

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
        if(health<=0){
            health=0;
        }
    }
}