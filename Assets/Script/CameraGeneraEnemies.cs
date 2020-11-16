using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Applicare questo script alla camera per far si che vangano visualizzati i punteggi fatti dal giocatore sullo schermo durante il gioco*/
public class CameraGeneraEnemies : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public GameObject bulletPrefab;
    
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
   
    public float respawnDueTime = 2.0f;
    private Vector2 screenBoundsDue;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsDue = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWaveDue());
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-0.60f, -3.0f));
    }

    private void spawnEnemyDue()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = new Vector2(screenBoundsDue.x * 2, Random.Range(-0.60f, -3.0f));
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
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
}
