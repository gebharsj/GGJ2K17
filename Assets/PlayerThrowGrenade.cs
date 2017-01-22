using UnityEngine;
using System.Collections;

public class PlayerThrowGrenade : MonoBehaviour
{
    public GameObject grenade;
    public float tossForce;
    int grenadeCount;
    string fireAxis;
    bool grenadeReady;

    void Start()
    {
        grenadeReady = true;
        if (gameObject.transform.parent.name == "PlayerOne")
        {
            fireAxis = "PlayerOneFire";
        }
        else if (gameObject.transform.parent.name == "PlayerTwo")
        {
            fireAxis = "PlayerTwoFire";
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
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(10);
        grenadeReady = true;
    }
}
