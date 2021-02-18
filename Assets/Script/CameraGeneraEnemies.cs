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
    
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
   
    public float respawnDueTime = 2.0f;
    private Vector2 screenBoundsDue;

    
    public float respawnTreTime = 3.0f;
    private Vector2 screenBoundsTre;

    public float respawnQuattroTime = 4.5f;
    private Vector2 screenBoundsQuattro;
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
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(0.5f,3.5f));
    }

    private void spawnEnemyDue()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(0.5f,3.5f));
    }

      private void spawnEnemyTre()
    {
        GameObject c = Instantiate(ciboPrefab) as GameObject;
        c.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(0.5f,3.5f));
    }

    private void spawnEnemyQuattro()
    {
        GameObject d = Instantiate(AltroPrefab) as GameObject;
        d.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(0.5f,3.5f));
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

            respawnDueTime = Random.Range(respawnTime+1, respawnTime+3);
            yield return new WaitForSeconds(respawnDueTime);
            spawnEnemyDue();
        }
    }

    IEnumerator asteroidWaveTre()
    {
        while (true)
        {
            respawnTreTime = Random.Range(respawnTime+2, respawnTime+4);
            yield return new WaitForSeconds(respawnTreTime);
            spawnEnemyTre();
        }
    }

    IEnumerator asteroidWaveQuattro()
    {
        while (true)
        {
           respawnQuattroTime = Random.Range(respawnTime+3, respawnTime+4);
            yield return new WaitForSeconds(respawnQuattroTime);
            spawnEnemyQuattro();
        }
    }
}
