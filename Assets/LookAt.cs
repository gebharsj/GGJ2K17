using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    public GameObject target;
    
	void Start ()
    {
	    
	}
	
	void Update ()
    {
        transform.LookAt(target.transform);
	}
}
