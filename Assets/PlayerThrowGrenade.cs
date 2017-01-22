using UnityEngine;
using System.Collections;

public class PlayerThrowGrenade : MonoBehaviour
{
    public GameObject grenade;
    public float tossForce;
    int grenadeCount;
    string fireAxis;
    bool grenadeReady;
    bool isPoweredUp;
    public int cooldown = 10;
    int oldCooldown;
    Coroutine cr;

    void Start()
    {
        oldCooldown = cooldown;
        grenadeReady = true;
        if (gameObject.transform.parent.name == "PlayerOne")
        {
            fireAxis = "PlayerOneFire2";
        }
        else if (gameObject.transform.parent.name == "PlayerTwo")
        {
            fireAxis = "PlayerTwoFire2";
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetAxis(fireAxis) > 0 && grenadeReady)
        {
            grenadeReady = false;
            GameObject newGrnade = Instantiate(grenade, transform.position, Quaternion.identity) as GameObject;
            newGrnade.GetComponent<Rigidbody>().AddForce(transform.up * tossForce * 1.7f);
            newGrnade.GetComponent<Rigidbody>().AddForce(transform.forward * tossForce);
             cr =  StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        grenadeReady = true;
    }

    public IEnumerator PowerUp()
    {
        StopCoroutine(cr);
        grenadeReady = true;
        cooldown = 1;
        yield return new WaitForSeconds(5);
        cooldown = oldCooldown;
    }
}
