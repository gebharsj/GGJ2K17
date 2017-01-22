using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().TookDamage(0.1f);
        }
    }
}
