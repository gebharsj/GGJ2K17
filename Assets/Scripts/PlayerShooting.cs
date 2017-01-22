using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public ParticleSystem[] beamParts;
    Animator anim;
    //public AudioSource audioSource;
    //public AudioClip shootingSound;
    string fireAxis;

    void Start()
    {
     //   audioSource = GetComponent<AudioSource>();
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
	
	void Update ()
    {
        if (Input.GetAxis(fireAxis) > 0 && !beamParts[0].enableEmission)
        {
            anim.SetBool("isShooting", true);
           // audioSource.PlayOneShot(shootingSound);
           foreach(ParticleSystem ps in beamParts)
            {
                ps.enableEmission = true;
            }
            //audioSource.Stop();
        }
        else if (Input.GetAxis(fireAxis) < 0.1f && beamParts[0].enableEmission)
        {
            anim.SetBool("isShooting", false);
            foreach (ParticleSystem ps in beamParts)
            {
                ps.enableEmission = false;
            }
        }
	}
}
