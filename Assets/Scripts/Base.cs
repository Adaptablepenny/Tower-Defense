using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text ScoreText;
    int score = 0;
    int baseHitpoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = baseHitpoints.ToString();
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BaseDamage();
        healthText.text = baseHitpoints.ToString();
    }

    public void BaseDamage()
    {
        baseHitpoints--;
        if(baseHitpoints <=0 )
        {
            print("Died");
        }
    }

    public void IncrementScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
}
