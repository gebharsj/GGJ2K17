using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveManger : MonoBehaviour
{
	[SerializeField]
	private int totalCap;
	[SerializeField]
	private Transform[] spawnPoints;
	private List<GameObject> activeEnemies = new List<GameObject>();
	[SerializeField]
	private float trickleEffectTimer, timeBetweenWaves, waveCounterUITimer;
	[SerializeField]
	Text waveText;
	private int currentCap, currentEnemies, waveCounter;
	private float roundEnemyLimit;
	private ObjectPooling enemyPool;
	private int enemyCount;

	void Start ()
    {
		waveCounter = 1;
		StartCoroutine(UpdateWaveText (waveCounter));
		enemyPool = GameObject.Find ("EnemyPool").GetComponent<ObjectPooling>();
		currentCap = totalCap;// change when an algorithm is made for the wave cap
		currentEnemies = currentCap;
		roundEnemyLimit = Mathf.RoundToInt(currentCap * .25f);
        enemyCount = Mathf.RoundToInt(roundEnemyLimit);
		StartCoroutine (Spawn());
	}
	IEnumerator Spawn()
    {
		for (int i = 0; i <= roundEnemyLimit; i++)
        {
			GameObject newEnemy = enemyPool.GetPooledObject ();
			activeEnemies.Add (newEnemy);
			newEnemy.transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
			ActivateEnemies (newEnemy);
			yield return new WaitForSeconds (trickleEffectTimer);
		}
	}
	void ActivateEnemies(GameObject enemy)
    {
		enemy.SetActive (true);
		enemy.GetComponent<Rigidbody> ().useGravity = true;
	}
	IEnumerator Respawn()
    {
        print("Respawn");
		for (enemyCount = enemyCount; enemyCount < roundEnemyLimit; enemyCount++)
        {
			if (enemyCount < currentCap)
            {
				GameObject newEnemy = enemyPool.GetPooledObject ();
				activeEnemies.Add (newEnemy);
				newEnemy.transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
				ActivateEnemies (newEnemy);
				yield return new WaitForSeconds (trickleEffectTimer);
			}
            else
            {
				yield return null;
			}
		}
	}
	public void EnemyDied(GameObject killedEnemy)
	{
		enemyCount--;
		currentEnemies--;
        print(currentEnemies);
        print(enemyCount);
        activeEnemies.Remove(killedEnemy);
        if (currentEnemies <= 0f)
        {
			StartCoroutine(NextWave());
		}
        else
        {
			if (enemyCount <= roundEnemyLimit * .5f)
            {
				StartCoroutine(Respawn ());
			}
		}
	}
	IEnumerator NextWave()
    {
        print("NextWave");
		currentCap = Mathf.RoundToInt( currentCap * 1.2f);
		currentEnemies = currentCap;
		roundEnemyLimit = Mathf.RoundToInt (currentCap * .25f);
		enemyCount = Mathf.RoundToInt(roundEnemyLimit);
		waveCounter++;
		StartCoroutine(UpdateWaveText (waveCounter));
		yield return new WaitForSeconds (timeBetweenWaves);
	}
	IEnumerator UpdateWaveText(int currentWave)
    {
		waveText.text = "Wave " + currentWave.ToString ();
		yield return new WaitForSeconds (waveCounterUITimer);
	}
}
