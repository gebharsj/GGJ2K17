using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    public string killer;
    public int damage = 1;
    int oldDamage;
    void Start()
    {
        oldDamage = damage;
    }

    void Update()
    {
        print("Damage: " + damage);
    }
	void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Health>().TookDamage(damage, killer);
        }
    }

    public IEnumerator PowerUp()
    {
        print("Powering up damage");
            damage = 100;
            yield return new WaitForSeconds(15);
            damage = oldDamage;
    }
}
