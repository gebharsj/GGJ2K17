using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    public string killer;

    void Start()
    {

    }

	void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Health>().TookDamage(1f, killer);
        }
    }
}
