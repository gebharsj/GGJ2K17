using UnityEngine;
using System.Collections;

public class FirstEnemy : MonoBehaviour {
	NavMeshAgent nav;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		nav.speed = 10f;
		nav.destination = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
