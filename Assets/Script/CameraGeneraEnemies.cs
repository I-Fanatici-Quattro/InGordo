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
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(0.5f,2.5f));
    }

    private void spawnEnemyDue()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(0.5f,2.5f));
    }

      private void spawnEnemyTre()
    {
        GameObject c = Instantiate(ciboPrefab) as GameObject;
        c.transform.position = new Vector2(screenBoundsTre.x * 2, Random.Range(0.5f,2.5f));
    }

    private void spawnEnemyQuattro()
    {
        GameObject d = Instantiate(AltroPrefab) as GameObject;
        d.transform.position = new Vector2(screenBoundsQuattro.x * 2, Random.Range(0.5f,2.5f));
    }

    private void spawnEnemyCinque()//fagiolo di balzar
    {
        GameObject e = Instantiate(Bobs) as GameObject;
        e.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(3f,3.4f));
    }

    private void spawnEnemySei()//fagiolo di balzar
    {
        GameObject f = Instantiate(water) as GameObject;
        f.transform.position = new Vector2(screenBoundsCinque.x * 2, Random.Range(2f,3.4f));
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime+(Random.Range(respawnTime+1, respawnTime+3)));
            spawnEnemy();
        }
    }

    IEnumerator asteroidWaveDue()
    {
        while (true)
        {
            respawnDueTime = Random.Range(respawnTime+2, respawnTime+3);
            yield return new WaitForSeconds(respawnDueTime);
            spawnEnemyDue();
        }
    }

    IEnumerator asteroidWaveTre()
    {
        while (true)
        {
            respawnTreTime = Random.Range(respawnDueTime+3, respawnDueTime+5);
            yield return new WaitForSeconds(respawnTreTime);
            spawnEnemyTre();
        }
    }

    IEnumerator asteroidWaveQuattro()
    {
        while (true)
        {
           respawnQuattroTime = Random.Range(respawnTreTime+3, respawnTreTime+4);
            yield return new WaitForSeconds(respawnQuattroTime);
            spawnEnemyQuattro();
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
