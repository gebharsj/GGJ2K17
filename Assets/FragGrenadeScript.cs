using UnityEngine;
using System.Collections;

public class FragGrenadeScript : MonoBehaviour
{
    public GameObject ring;
    public GameObject explosion;

    void Start()
    {
        StartCoroutine(Shrink());
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Ground")
        {
            GameObject ringEffect = Instantiate(ring, other.contacts[0].point, other.transform.rotation) as GameObject;
            ringEffect.name = ring.name.Substring(0, 13);
            ringEffect.transform.SetParent(null);
        }
    }

    IEnumerator Shrink()
    {
        for(int i = 0; i < 20; i++)
        {
            transform.localScale -= new Vector3(.1f, .1f, .1f);
            yield return new WaitForSeconds(.6f);
        }
        Destroy(gameObject);
    }
}

