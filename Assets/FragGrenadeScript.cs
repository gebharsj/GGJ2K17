using UnityEngine;
using System.Collections;

public class FragGrenadeScript : MonoBehaviour {
    [SerializeField]
    private float fuseTimer, blastRadius, blastForce, blastUpwardsMod, throwForce;

    Rigidbody _rb;

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * throwForce);
        StartCoroutine(FragExplosion());
    }	
	IEnumerator FragExplosion()
    {
        yield return new WaitForSeconds(fuseTimer);
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach(Collider go in colliders)
        {
            if(go.tag == "Enemy")
            {
                yield return new WaitForSeconds(.1f);
                print(go.name);
                go.attachedRigidbody.constraints = RigidbodyConstraints.None;
                go.attachedRigidbody.AddExplosionForce(blastForce, this.gameObject.transform.position, blastRadius, blastUpwardsMod);
                yield return new WaitForSeconds(.1f);
            }
        }
        this.gameObject.SetActive(false);
   }
}

