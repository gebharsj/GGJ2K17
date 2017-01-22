using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject[] powerUpSpawnPoints;
    public static bool powerUpActive;

	void Update ()
    {
	    if(!powerUpActive)
        {
            powerUpActive = true;
            int randomPowerUp = Random.Range(0, powerUps.Length);
            int randomSpawnLocation = Random.Range(0, powerUpSpawnPoints.Length);
            Instantiate(powerUps[randomPowerUp], powerUpSpawnPoints[randomSpawnLocation].transform.position, Quaternion.identity);
        }
	}
}
