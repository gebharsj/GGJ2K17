using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
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
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        switch (type)
        {
            case PowerUpType.None:
                Debug.LogError("The power up type has not been assigned!");
                break;
            case PowerUpType.Speed:
                originalSpeed = player.GetComponent<PlayerMovement>().speed;
                player.GetComponent<PlayerMovement>().speed = 100;
                StartCoroutine(PowerUpTimer());
                player.GetComponent<PlayerMovement>().speed = originalSpeed;
                Destroy(gameObject);
                break;
            //case PowerUpType.Damage:
            //    originalDamage = player.GetComponentInChildren<Damage>().;
            //    player.GetComponentInChildren<Damage>().damageDone *= 10;
            //    StartCoroutine(PowerUpTimer());
            //    player.GetComponentInChildren<Damage>().damageDone = originalDamage;
            //    Destroy(gameObject);
            //    break;
            case PowerUpType.SuperJump:
                originalJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
                player.GetComponent<PlayerMovement>().jumpForce *= 3;
                StartCoroutine(PowerUpTimer());
                player.GetComponent<PlayerMovement>().jumpForce = originalJumpForce;
                Destroy(gameObject);
                break;
            //case PowerUpType.Grenade:
            //    originalCooldown = player.GetComponent<TossGrenade>().cooldown;
            //    player.GetComponent<TossGrenade>().cooldown = 1;
            //    StartCoroutine(PowerUpTimer());
            //    player.GetComponent<TossGrenade>().cooldown = originalCooldown;
            //    Destroy(gameObject);
            //    break;
        }
    }
    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(10);
    }
}