using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public ParticleSystem[] beamParts;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && !beamParts[0].enableEmission)
        {
            anim.SetBool("isShooting", true);
            foreach (ParticleSystem ps in beamParts)
            {
                ps.enableEmission = true;
            }
        }
        else if (Input.GetAxis("Fire1") < 0.1f && beamParts[0].enableEmission)
        {
            anim.SetBool("isShooting", false);
            foreach (ParticleSystem ps in beamParts)
            {
                ps.enableEmission = false;
            }
        }
    }
}