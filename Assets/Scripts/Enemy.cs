using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
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
            var deathfx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            deathfx.Play();
            Destroy(gameObject);
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        hitExplosion.Play();
    }
}



