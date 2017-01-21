using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public GameObject beam;
    Animator anim;
    string fireAxis;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (gameObject.name == "PlayerOne")
        {
            fireAxis = "PlayerOneFire";
        }
        else if (gameObject.name == "PlayerTwo")
        {
            fireAxis = "PlayerTwoFire";
        }
    }
	
	void Update () {
        if (Input.GetAxis(fireAxis) > 0 && !beam.activeInHierarchy)
        {
            anim.SetBool("isShooting", true);
            beam.SetActive(true);
        }
        else if (Input.GetAxis(fireAxis) < 0.1f && beam.activeInHierarchy)
        {
            anim.SetBool("isShooting", false);
            beam.SetActive(false);
        }
	}
}
