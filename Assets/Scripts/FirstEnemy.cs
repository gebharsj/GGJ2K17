using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstEnemy : MonoBehaviour {
	private NavMeshAgent nav;
	[SerializeField]
	private List<GameObject> targets; // array of targets
    [SerializeField]
    private float speed; // checking distance is for when a player enters the enemy's trigger. If the current target is too far away then theTarget will become the player that the enemy collided with.

	private GameObject theTarget;// the actual target
	private int _target; // the target selector 
                         // Use this for initialization
    GameManager gameManager;
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        foreach(GameObject go in gameManager.players)
        {
            targets.Add(go);
        }
		nav = GetComponent<NavMeshAgent> ();
		_target = Random.Range (0, targets.Count);
		theTarget = targets[_target];
		print (theTarget);
		Chase ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("Chase");
		if (!theTarget.activeInHierarchy)
		{
			for(int i = 0; i < targets.Count; i++)
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
