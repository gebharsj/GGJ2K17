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
        if ((transform.name != "PlayerOneRing" && transform.name != "PlayerTwoRing" &&  other.name == "PlayerOne" ||
            (transform.name != "PlayerOneRing" && transform.name != "PlayerTwoRing" && other.name == "PlayerTwo")))    //&& transform.name != "PlayerRing"
        {
            other.GetComponent<Health>().TookDamage(1);
        }
        else if(transform.name == "PlayerOneRing" && other.tag == "Enemy" || transform.name == "PlayerTwoRing" && other.tag == "Enemy")
        {
            other.GetComponent<Health>().TookDamage(1);
        }
        else if(transform.name == "PlayerOneRing" && other.name == "PlayerTwo")
        {
            StartCoroutine(other.GetComponent<PlayerMovement>().Stun());
        }
        else if(transform.name == "PlayerTwoRing" && other.name == "PlayerOne")
        {
            StartCoroutine(other.GetComponent<PlayerMovement>().Stun());
        }
    }
}
