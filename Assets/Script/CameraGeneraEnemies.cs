using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Applicare questo script alla camera per far si che vangano visualizzati i punteggi fatti dal giocatore sullo schermo durante il gioco*/
public class CameraGeneraEnemies : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public GameObject bulletPrefab;
    public GameObject ciboPrefab;
    public GameObject AltroPrefab;
    public GameObject Bobs;
    public GameObject water;
    public GameObject platforms;
    public GameObject platformsDue;

    //booleani per autorizzare la creazione dei cibi da inviare

    bool a1=false;
    bool b1=false;
    bool c1=false;
    bool d1=false;
    bool platLong=false;

    float randomico=0f;
    float randomicoOggetti=0f;
    float respawnGeneral=5f;
    //bool e1=false;
    
    /////////

    float respawnTime = 1.0f;
    private Vector2 screenBounds;
   
     float respawnDueTime = 2.0f;
    private Vector2 screenBoundsDue;

    
     float respawnTreTime = 3.0f;
    private Vector2 screenBoundsTre;

     float respawnQuattroTime = 4.5f;
    private Vector2 screenBoundsQuattro;

     float respawnCinqueTime =100f;
    private Vector2 screenBoundsCinque;//fagiolo di balzar
    public Score h;

    float respawnSeiTime =20f;
    private Vector2 screenBoundsSei;

    float respawnPlatformsTime =5f;
    private Vector2 screenBoundsPlatforms;

    float respawnPlatformsDueTime =5f;
    private Vector2 screenBoundsPlatformsDue;


    
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsDue = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveDue());
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());

        screenBoundsTre = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveTre());

        screenBoundsQuattro = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveQuattro());

        screenBoundsCinque = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveCinque());

        screenBoundsSei = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveSei());

        screenBoundsPlatforms = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWavePlatforms());

        screenBoundsPlatformsDue = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWavePlatformsDue());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        if((Random.Range(0.0f,10))%2==0){
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-0.6f,0.42f));
        }
        else{
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(3.02f,3.4f));
        }
    }

    private void spawnEnemyDue()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        if((Random.Range(0,10))%2==0){
            b.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(-0.6f,0.42f));
        }
        else{
            b.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(3.02f,3.4f));
        }
    }

      private void spawnEnemyTre()
    {
        GameObject c = Instantiate(ciboPrefab) as GameObject;
        if((Random.Range(0,10))%2==0){
            c.transform.position = new Vector2(screenBoundsTre.x* 2, Random.Range(-0.6f,0.42f));
        }
        else{
            c.transform.position = new Vector2(screenBoundsTre.x * 2, Random.Range(3.02f,3.4f));
        }
    }

    private void spawnEnemyQuattro()
    {
        GameObject d = Instantiate(AltroPrefab) as GameObject;
        if((Random.Range(0,10))%2==0){
            d.transform.position = new Vector2(screenBoundsQuattro.x* 2, Random.Range(-0.6f,0.42f));
        }
        else{
            d.transform.position = new Vector2(screenBoundsQuattro.x * 2, Random.Range(3.02f,3.4f));
        }
    }

    private void spawnEnemyCinque()//fagiolo di balzar
    {
        GameObject e = Instantiate(Bobs) as GameObject;
        e.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(3.02f,3.4f));
    }

    private void spawnEnemySei()//acqua
    {
        GameObject f = Instantiate(water) as GameObject;
        f.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(3.02f,3.4f));
    }

    private void spawnEnemyPlatforms()//piattaforme per camminare in aria
    {
        GameObject g = Instantiate(platforms) as GameObject;
        g.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(1.57f,1.57f));
    }

    private void spawnEnemyPlatformsDue()//piattaforme per camminare in aria
    {
        GameObject h = Instantiate(platformsDue) as GameObject;
        h.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(1.57f,1.57f));
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            respawnGeneral = Random.Range(2,6);
            yield return new WaitForSeconds(respawnGeneral);
            if(b1==false && c1==false && d1==false){
                a1=true;
                yield return new WaitForSeconds(respawnTime+(Random.Range(respawnTime+1, respawnTime+3)));
                randomico=Random.Range(0,9);
                if((Random.Range(0,9))%2==0){
                    if(!platLong){
                    yield return new WaitForSeconds(2.0f);
                    spawnEnemyPlatforms();    
                    }
                }
                yield return new WaitForSeconds(1.0f);
                spawnEnemy();
                
                a1=false;
            }
        }
    }

    IEnumerator asteroidWaveDue()
    {
        while (true)
        {
            respawnGeneral = Random.Range(2,6);
            yield return new WaitForSeconds(respawnGeneral);
            if(a1==false && c1==false && d1==false){
                b1=true;
                respawnDueTime = Random.Range(respawnTime+2, respawnTime+3);
                yield return new WaitForSeconds(respawnDueTime);
                randomico=Random.Range(0,9);
                if((Random.Range(0,9))%2==0){
                    if(!platLong){
                    yield return new WaitForSeconds(2.0f);
                    spawnEnemyPlatforms();
                    }
                }
                yield return new WaitForSeconds(1.0f);
                spawnEnemyDue();
                b1=false;
            }
        }
    }

    IEnumerator asteroidWaveTre()
    {
        while (true)
        {
            respawnGeneral = Random.Range(2,6);
            yield return new WaitForSeconds(respawnGeneral);
             if(a1==false && b1==false && d1==false){
                c1=true;
                respawnTreTime = Random.Range(respawnDueTime+3, respawnDueTime+5);
                yield return new WaitForSeconds(respawnTreTime);
                randomico=Random.Range(0,9);
                if((Random.Range(0,9))%2==0){
                    if(!platLong){
                    yield return new WaitForSeconds(2.0f);
                    spawnEnemyPlatforms();
                    }
                }
                yield return new WaitForSeconds(1.0f);
                spawnEnemyTre();
                c1=false;
            }
        }
    }

    IEnumerator asteroidWaveQuattro()
    {
        while (true)
        {
            respawnGeneral = Random.Range(2,6);
            yield return new WaitForSeconds(respawnGeneral);
             if(a1==false && b1==false && c1==false){
                d1=true;
                respawnQuattroTime = Random.Range(respawnTreTime+3, respawnTreTime+4);
                yield return new WaitForSeconds(respawnQuattroTime);
                randomico=Random.Range(0,9);
                if((Random.Range(0,9))%2==0){
                    if(!platLong){
                    yield return new WaitForSeconds(2.0f);
                    spawnEnemyPlatforms();
                    }
                }
                yield return new WaitForSeconds(1.0f);
                spawnEnemyQuattro();
                
                d1=false;
            }
        }
    }

    IEnumerator asteroidWavePlatforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            if(!platLong)
            {
            spawnEnemyPlatforms();
            }
        }
    }

    IEnumerator asteroidWavePlatformsDue()
    {
        while (true)
        { //cambia 30 secondi
            platLong=true;
            yield return new WaitForSeconds(25f);
            spawnEnemyPlatformsDue();
            yield return new WaitForSeconds(3f); 
            platLong=false;
            yield return new WaitForSeconds(40f);
        }
    }

    IEnumerator asteroidWaveCinque()//fagiolo
    {
        while (true)
        {
            if(h.health<=5){
                yield return new WaitForSeconds(20f);
                spawnEnemyDue();  
            }

            //respawnCinqueTime = Random.Range(respawnCinqueTime+3, respawnCinqueTime+4);
            yield return new WaitForSeconds(respawnCinqueTime);
            spawnEnemyCinque();
        }
    }

    IEnumerator asteroidWaveSei()//acqua
    {
        while (true)
        {
           respawnSeiTime = Random.Range(respawnSeiTime+3, respawnSeiTime+4);
            yield return new WaitForSeconds(respawnSeiTime);
            spawnEnemySei();
        }
    }
}
