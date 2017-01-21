using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public GameObject beam;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") > 0 && !beam.activeInHierarchy)
        {
            anim.SetBool("isShooting", true);
            beam.SetActive(true);
        }
        else if (Input.GetAxis("Fire1") < 0.1f && beam.activeInHierarchy)
        {
            anim.SetBool("isShooting", false);
            beam.SetActive(false);
        }
	}
}
