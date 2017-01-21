using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float baseHealth;
    float health;
    WaveManger waveManager;

    void Start()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManger>();
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
        if(transform.tag == "Enemy")
        {
            waveManager.EnemyDied(gameObject);
            gameObject.SetActive(false);
        }
        else
        gameObject.SetActive(false);
    }
}
