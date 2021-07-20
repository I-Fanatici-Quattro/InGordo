using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviementoEnemy : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    private Rigidbody2D rb;
    Vector2 screenBounds;
    //public float Rotazione=50.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector2.up * Rotazione * Time.deltaTime);
       if(transform.position.x < -20.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }


    }
}
