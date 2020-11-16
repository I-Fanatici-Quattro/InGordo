using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* moviemnto del giocatore ecollisioni con gli oggetti*/
public class DinoPlayer : MonoBehaviour
{
    [SerializeField]
    int salto=4;
    public bool IJ;
    public int point=0;
    public Text scoreText;

    public Text currentScore;
    public Text highScore;
    public int Score = 0;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
       IJ =false;

       PlayerPrefs.SetInt("BestScore", 0);
       highScore.text = PlayerPrefs.GetInt("BestScore").ToString();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && IJ==false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,salto,0);
            IJ=true;
        }


        Score++;
        currentScore.text = Score.ToString();

        if (Score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", Score);
            highScore.text = PlayerPrefs.GetInt("BestScore").ToString();
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

        if(coll.gameObject.tag=="bullet")
        {
            audio.Play();
            point++;
            scoreText.text = point.ToString();
        }

        if (coll.gameObject.tag == "proiett")
        {
            audio.Play();
            if (point >= 2)
            {
                point = point - 2;
            }
            else
                point = 0;
           
            scoreText.text = point.ToString();
        }
    }
}
