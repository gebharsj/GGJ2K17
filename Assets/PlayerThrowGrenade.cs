using UnityEngine;
using System.Collections;

public class PlayerThrowGrenade : MonoBehaviour {
    [SerializeField]
    KeyCode throwingKey;
    [SerializeField]
    Transform grenadeSpawn;
    [SerializeField]
    GameObject frag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(throwingKey))
        {
            GameObject clone = Instantiate(frag, grenadeSpawn.position, transform.rotation) as GameObject;
        }
	}
}
