using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour
{
	IEnumerator Start ()
    {
        for(int i = 0; i < 100; i++)
        {
            transform.localScale += new Vector3(1, 1, 0);
            yield return new WaitForSeconds(.05f);
        }
        Destroy(gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerOne" || other.name == "PlayerTwo")
        {
            other.GetComponent<Health>().TookDamage(1);
        }
    }
}
