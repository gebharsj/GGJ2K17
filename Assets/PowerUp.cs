using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    bool started;
    public enum PowerUpType
    {
        None,
        Speed,
        Damage,
        SuperJump,
        Grenade,
    }

    float originalSpeed;
    int originalDamage;
    float originalJumpForce;
    float originalCooldown;

    public PowerUpType type = PowerUpType.None;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerOne")
        {
            ApplyPowerUp(other.gameObject);   
        }
        else if (other.name == "PlayerTwo")
        {
            ApplyPowerUp(other.gameObject);
        }
    }

    void ApplyPowerUp(GameObject player)
    {
        PowerUpSpawner.powerUpActive = false;
        switch (type)
        {
            case PowerUpType.None:
                Debug.LogError("The power up type has not been assigned!");
                break;
            case PowerUpType.Speed:
                player.GetComponent<PowerUpManager>().PowerUpChosen("Speed");
                break;
            case PowerUpType.Damage:
                player.GetComponent<PowerUpManager>().PowerUpChosen("Damage");
                break;
            case PowerUpType.SuperJump:
                player.GetComponent<PowerUpManager>().PowerUpChosen("Jump");
                break;
            case PowerUpType.Grenade:
                player.GetComponent<PowerUpManager>().PowerUpChosen("Grenade");
                break;
        }
        Destroy(gameObject);
    }
}