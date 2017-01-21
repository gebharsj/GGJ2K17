using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<GameObject> players;

    void Start()
    {
        GameObject playerOne = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        playerOne.name = "PlayerOne";
        players.Add(playerOne);

        GameObject playerTwo = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        playerOne.name = "PlayerTwo";
        players.Add(playerTwo);
    }
}
