using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float baseHealth;
    float health;
    TheWaveManager waveManager;
    Animator anim;
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        waveManager = GameObject.Find("WaveManager").GetComponent<TheWaveManager>();
        health = baseHealth;
        
        if(transform.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
        }
    }

    void OnEnable()
    {
        health = baseHealth;
    }
    
    public void TookDamage(float damage)
    {
        health = health - damage;
        if (gameObject.tag == "Player")
            healthBar.fillAmount = health / 100.0f;

        if(health <= 0)
        {
            StartCoroutine(WasDestroyed());
        }
    }

    public IEnumerator WasDestroyed()
    {
        if(transform.tag == "Enemy")
        {
            nav.speed = 0f;
            gameObject.GetComponent<FirstEnemy>().enabled = false;
            int randomDeath = Random.Range(1, 3);
            anim.SetInteger("HasDied", randomDeath);
            yield return new WaitForSeconds(7f);
            waveManager.EnemyDied(gameObject);
            gameObject.SetActive(false);
        }
        else
        gameObject.SetActive(false);
    }
}
