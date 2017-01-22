using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TheWaveManager : MonoBehaviour {
    [SerializeField]
    private float _MaxHp, _AllowedHp, _CurrentHpUsed, _AllowedHpIncreaseAmount, _RoundHPLimit, _RoundHPUsed, spawnDelay;
    [SerializeField]
    Transform[] enemySpawnPoints;
    private int newEnemyCount, waveCounter;
    ObjectPooling enemyPool;
    List<GameObject> activeEnemies = new List<GameObject>();
    bool canSpawn = false;
    public Text waveCountText;
    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyPool = GameObject.Find("EnemyPool").GetComponent<ObjectPooling>();
        StartCoroutine(StartWave());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator StartWave()
    {
        waveCounter++;
        waveCountText.text = "Wave: " + waveCounter;
        _RoundHPUsed = 0;
        if(_AllowedHp < _MaxHp)
        {
            _RoundHPLimit += _AllowedHpIncreaseAmount;
            _AllowedHp = _RoundHPLimit / 2;
        }
        
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
        Spawn();
    }
    void Spawn()
    {
        if(canSpawn)
        {
            if (_RoundHPUsed < _RoundHPLimit)
            {
                while (_CurrentHpUsed < _AllowedHp)
                {
                    GameObject newEnemy = enemyPool.GetPooledObject();
                    if (newEnemy == null)
                    {
                        return;
                    }
                    int choosePlayer = Random.Range(0, 1);
                    newEnemy.transform.position = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;

                    // new Vector3(Random.Range(gameManager.players[choosePlayer].transform.position.x - 20,
                    //gameManager.players[choosePlayer].transform.position.x + 20),0,
                        //Random.Range(gameManager.players[choosePlayer].transform.position.z - 20,
                        //gameManager.players[choosePlayer].transform.position.z + 20));
                    newEnemy.name = "Enemy";
                    newEnemy.SetActive(true);
                    activeEnemies.Add(newEnemy);
                    _CurrentHpUsed += newEnemy.GetComponent<Health>().baseHealth;
                    _RoundHPUsed += newEnemy.GetComponent<Health>().baseHealth;

                    if (_RoundHPUsed >= _RoundHPLimit)
                    {
                        canSpawn = false;
                    }
                }
            }
        }
    }

    public void EnemyDied(GameObject killedEnemy)
    {
        _CurrentHpUsed -= killedEnemy.GetComponent<Health>().baseHealth;
        activeEnemies.Remove(killedEnemy);
        if(_CurrentHpUsed < _AllowedHp)
        {
            Spawn();            
        }

        if(_RoundHPUsed >= _RoundHPLimit && activeEnemies.Count <= 0)
            StartCoroutine(StartWave());
    }
}
