using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    void Start()
    {

    }

	void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Health>().TookDamage(1f);
        }
    }
}
