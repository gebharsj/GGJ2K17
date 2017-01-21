using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public List<GameObject> players;

    void Start()
    {
        GameObject playerOne = Instantiate(player1Prefab, transform.position, Quaternion.identity) as GameObject;
        playerOne.name = "PlayerOne";
        players.Add(playerOne);

        GameObject playerTwo = Instantiate(player2Prefab, transform.position, Quaternion.identity) as GameObject;
        playerTwo.name = "PlayerTwo";
        players.Add(playerTwo);
    }
}
