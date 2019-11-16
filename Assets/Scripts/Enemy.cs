using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int hitPoints = 1;
    [SerializeField] ParticleSystem hitExplosion;
    [SerializeField] ParticleSystem deathExplosion;
    
    

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnParticleCollision(GameObject enemy)
    {
        
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Base mainBase = GameObject.FindObjectOfType(typeof(Base)) as Base;
        mainBase.IncrementScore();
        var deathfx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        deathfx.Play();
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--;
        hitExplosion.Play();
    }
}



