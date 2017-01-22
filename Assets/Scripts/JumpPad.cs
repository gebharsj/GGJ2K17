using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

    public float forceAmount;
    public enum Direction
    {
        Forward,
        Up,
    }

    public Direction forceDirection = Direction.Up;

	void OnTriggerEnter(Collider other)
    {
        switch(forceDirection)
        {
            case Direction.Forward:
                other.GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.VelocityChange);
                break;
            case Direction.Up:
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * forceAmount, ForceMode.VelocityChange);
                break;
            default:
                break;
        }        
    }
}
