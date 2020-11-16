using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBg : MonoBehaviour
{

    float lastCamerax;
    float currentCamerax;

    [SerializeField] 
    float parallaxSpeed = 3f;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main.transform;
        lastCamerax=cam.position.x;
        currentCamerax=lastCamerax;
    }

    // Update is called once per frame
    void Update()
    {
       currentCamerax=cam.position.x;
       float delta=currentCamerax - lastCamerax;
       if(Mathf.Abs(delta) > 0)
       {
           Vector3 newPos = new Vector3(transform.position.x - delta,transform.position.y,transform.position.z);
           transform.position=Vector3.MoveTowards(transform.position,newPos,Time.deltaTime * parallaxSpeed);

           lastCamerax=currentCamerax;
       } 
    }
}
