using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float baseHealth;
    [HideInInspector]
    public float health;
    TheWaveManager waveManager;
    Animator anim;
    NavMeshAgent nav;
    string killer;
    int lives = 3;

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
            healthBar.fillAmount = health / 100.0f;

        if(health <= 0)
        {
            StartCoroutine(WasDestroyed());
        }
    }

    public void TookDamage(float damage, string myKiller)
    {
        killer = myKiller;
        health = health - damage;
            healthBar.fillAmount = health / 100.0f;

        if (health <= 0)
        {
            StartCoroutine(WasDestroyed());
        }
    }
    
    public IEnumerator WasDestroyed()
    {
        if(transform.tag == "Enemy")
        {
            nav.velocity = Vector3.zero;
            int randomDeath = Random.Range(1, 3);
            anim.SetInteger("HasDied", randomDeath);
            yield return new WaitForSeconds(5f);
            anim.Stop();
            if (killer == "PlayerOne")
                GameManager.playerOneScore++;
            else if(killer == "PlayerTwo")
                GameManager.playerTwoScore++;
            waveManager.EnemyDied(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
            gameObject.SetActive(true);
            lives--;
            if(lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
