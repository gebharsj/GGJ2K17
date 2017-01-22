using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "PlayerOne" || other.name == "PlayerTwo")
        {
            other.GetComponent<Health>().TookDamage(0.1f);
        }
    }
}
