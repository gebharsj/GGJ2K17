using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TossGrenade : MonoBehaviour
{
    public GameObject grenade;
    public float tossForce;
    int grenadeCount;
    string fireAxis;
    
    void Start()
    {
        if (gameObject.name == "PlayerOne")
        {
            fireAxis = "PlayerOneFire";
        }
        else if (gameObject.name == "PlayerTwo")
        {
            fireAxis = "PlayerTwoFire";
        }
    }
    
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetAxis(fireAxis) > 0)
        {
            GameObject newGrnade = Instantiate(grenade, transform.position, Quaternion.identity) as GameObject;
            newGrnade.GetComponent<Rigidbody>().AddForce(transform.forward * tossForce);
        }
    }
}