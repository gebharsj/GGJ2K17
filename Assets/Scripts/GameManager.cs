using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public List<GameObject> players;
    public Text p1Score;
    public Text p2Score;
    public static int playerOneScore;
    public static int playerTwoScore;

    void Start()
    {
        GameObject playerOne = Instantiate(player1Prefab, transform.position, Quaternion.identity) as GameObject;
        playerOne.name = "PlayerOne";
        players.Add(playerOne);

        GameObject playerTwo = Instantiate(player2Prefab, transform.position + new Vector3(0,0,3), Quaternion.identity) as GameObject;
        playerTwo.name = "PlayerTwo";
        players.Add(playerTwo);

        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void LateUpdate()
    {
        p1Score.text = "Player One Score: " + playerOneScore;
        p2Score.text = "Player Two Score: " + playerTwoScore;
    }
}
