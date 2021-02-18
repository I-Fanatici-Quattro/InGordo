using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Vita : MonoBehaviour
{

    public float maxhealth=100;

    float health;

    Image healthBar;
    float barWidth,barHeight;
    float healtCurrent;
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
        
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
