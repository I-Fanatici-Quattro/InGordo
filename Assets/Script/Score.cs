using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    //timer per la vita
    public static float t=5f;//tempo che serve a misurare dopo quanto il conta chilometri si deve aggiornare
    public static float t1=20f;//tempo timer dopo il quale il personaggio perde vita perché non si nutre

    //Punteggio chilometri
    [SerializeField]
    //public Text PuntiText;

    public Text metri;
    public Text chilometri;
    
    //public Text highScore;
    public int scoreM = 0;//quanti metri
    public int scoreK = 0;//quanti chilometri

    //vita Personaggio
    float maxhealth=100;

    public float health;

    Image healthBar;
    float barWidth,barHeight,healtCurrent;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar= GameObject.FindGameObjectWithTag("barraVita").GetComponent<Image>();
        health=maxhealth;

        barWidth=healthBar.rectTransform.sizeDelta.x;
        barHeight= healthBar.rectTransform.sizeDelta.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;//scaduto il tempo, i metri aumentano
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

        t1 -=Time.deltaTime;//se questo tempo scade, la vita si decrementa (NON STAI MANGIANDO)
        while(t1<0){
            DelVita();
            t1=20;
        }

        if(health==0)
        {
            Application.LoadLevel ("InGordo");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(health>=20){//se la vita è maggiore di un certo valore, allora tutto normale
            if(other.gameObject.tag=="good")
            {
                AddScore(2);
                t1=20;//ogni volta che il personaggio mangia il timer si resetta 
            }

            if (other.gameObject.tag =="bad")
            {
                DelVita();
                t1=20;//ogni volta che il personaggio mangia il timer si resetta
            }

            if (other.gameObject.tag =="god")
            {
                //DelScore();
                float ripristino=maxhealth-healtCurrent;
                AddScore(ripristino);
                t1=20;//ogni volta che il personaggio mangia, il timer si resetta 
            }

            if (other.gameObject.tag =="water")
            {
                AddScore(5);
                t1=20;//ogni volta che il personaggio mangia, il timer si resetta 
            }
        }
        else{//se la vita è minore di un certo valore, hai comunque bisogno di un po' di zuccheri, quindi anche i cibi malsani possono salvarti
           if(other.gameObject.tag =="bad" || other.gameObject.tag=="good"){
                AddScore(2);
                t1=20;//ogni volta che il personaggio mangia il timer si resettA
            }
        }
    }

    void AddScore(float a)//aggiungi il punteggio specificato dalla variabile a e, inoltre, in base alla percentuale della vita, aggiorna il colore della barra
    {
        if(health>0 && health!=100){
            health +=a;
            healtCurrent = (health * barWidth) / maxhealth;
            healthBar.rectTransform.sizeDelta = new Vector2(healtCurrent, barHeight);

            if(health>65 && health<100){
                    healthBar.GetComponent<Image>().color = new Color32(35,255,0,255);//verde
            }
            if(health>25 && health<=65){
                    healthBar.GetComponent<Image>().color = new Color32(255,128,0,255);//arancione
            }

            if(health>0 && health<=25){
                    healthBar.GetComponent<Image>().color = new Color32(255,0,0,255);//rosso
            }
        }
    }

    void DelVita()//DECREMENTA la vita del personaggio quando entra in collisione con cibi non sani
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
        if(health<=0){
            health=0;
        }
    }
}