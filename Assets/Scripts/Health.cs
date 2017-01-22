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

    public Text playerOneLives;
    public Text playerTwoLives;
    public Text playerOneRespawnTimer;
    public Text playerTwoRespawnTimer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        waveManager = GameObject.Find("WaveManager").GetComponent<TheWaveManager>();
        health = baseHealth;
        
        if(transform.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
        }
        else if(transform.name == "PlayerOne")
        {
            playerOneLives = GameObject.Find("Player1Lives").GetComponent<Text>();
            playerOneLives.text = "Lives left: " + lives;
            playerOneRespawnTimer = GameObject.Find("Player1RespawnTimer").GetComponent<Text>();
            playerOneRespawnTimer.enabled = false;
        }
        else if(transform.name == "PlayerTwo")
        {
            playerTwoLives = GameObject.Find("Player2Lives").GetComponent<Text>();
            playerTwoLives.text = "Lives left: " + lives;
            playerTwoRespawnTimer = GameObject.Find("Player2RespawnTimer").GetComponent<Text>();
            playerTwoRespawnTimer.enabled = false;
        }
    }

    void OnEnable()
    {
        health = baseHealth;
    }
    
    public void TookDamage(float damage)
    {
        health = health - damage;
        healthBar.fillAmount = health / baseHealth;

        if(health <= 0)
        {
            StartCoroutine(WasDestroyed());
        }
    }

    public void TookDamage(float damage, string myKiller)
    {
        killer = myKiller;
        health = health - damage;
        healthBar.fillAmount = health / baseHealth;

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
            lives--;
            if (lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            gameObject.SetActive(false);
            transform.position = Vector3.zero;

            if (transform.name == "PlayerOne")
            {
                playerOneLives.text = "Lives Left: " + lives;
                playerOneRespawnTimer.enabled = true;
                for (int i = 5; i > 0; i--)
                {
                    playerOneRespawnTimer.text = "Respawning in " + i + "...";
                }
                playerOneRespawnTimer.enabled = false;
            }
            else
            {
                playerTwoLives.text = "Lives Left: " + lives;
                playerTwoRespawnTimer.enabled = true;
                for (int i = 5; i > 0; i--)
                {
                    playerTwoRespawnTimer.text = "Respawning in " + i + "...";
                }
                playerTwoRespawnTimer.enabled = false;
            }
            gameObject.SetActive(true);
        }
    }
}
