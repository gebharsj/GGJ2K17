using UnityEngine;
using System.Collections;

public class FirstEnemy : MonoBehaviour {
	private NavMeshAgent nav;
	[SerializeField]
	private GameObject[] targets; // array of targets
	[SerializeField]
	private float speed, checkingDistance; // checking distance is for when a player enters the enemy's trigger. If the current target is too far away then theTarget will become the player that the enemy collided with.

	private GameObject theTarget;// the actual target
	private int _target; // the target selector 
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		_target = Random.Range (0, targets.Length);
		theTarget = targets [_target];
		print (theTarget);
		Chase ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("Chase");
		if (!theTarget.activeInHierarchy)
		{
			for(int i = 0; i < targets.Length; i++)
			{
				if (targets [i].activeInHierarchy)
					theTarget = targets [i].gameObject;
			}

			if (!theTarget.activeInHierarchy) {
				print("I have no targets");
				//Do nothing
			}
			else
			Chase ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
			Attack ();
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
				Chase ();
		}
	}
	void Attack(){// adding to the attack function later on in the jam
		//print ("attack");
		nav.speed = 0f;
	}
	void Chase()
	{
		nav.destination = theTarget.transform.position;
		nav.speed = speed;
	}
}
