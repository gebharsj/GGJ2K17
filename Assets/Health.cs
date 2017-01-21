using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float baseHealth;
    public float health;

    void Start()
    {
        health = baseHealth;
    }
    
    public void TookDamage(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            WasDestroyed();
        }
    }

    public void WasDestroyed()
    {
        gameObject.SetActive(false);
    }

    //void OnParticleCollision(GameObject other)
    //{
    //    if(gameObject.name == "Enemy")
    //    {
    //        if(other.tag == "PlayerBeam")
    //        {
    //            TookDamage(1);
    //        }
    //    }
    //}
}
