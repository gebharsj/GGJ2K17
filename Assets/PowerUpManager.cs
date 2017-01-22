using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    Damage damageScript;
    PlayerThrowGrenade playerThrowGrenade;
    bool active;
    float lastTime;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        damageScript = GetComponentInChildren<Damage>();
        playerThrowGrenade = GetComponentInChildren<PlayerThrowGrenade>();
    }

    public void PowerUpChosen(string type)
    {
        switch(type)
        {
            case "Speed":
                StartCoroutine(playerMovement.PowerUp());
                break;
            case "Damage":
                StartCoroutine(damageScript.PowerUp());
                break;
            case "Jump":
                StartCoroutine(playerMovement.JumpPowerUp());
                break;
            case "Grenade":
                StartCoroutine(playerThrowGrenade.PowerUp());
                break;
        }
    }        
}
