using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	private const float Y_Angle_Min = 0.0f;
	private const float Y_Angle_Max = 50.0f;
	[SerializeField]
	Transform lookAt, camTransform;
	private Camera main;
	Vector3 dir;
	Quaternion rotation;
	private float distance =10.0f, currentX = 0.0f, currentY = 0.0f;
	// Use this for initialization
	void Start () {
		camTransform = transform;
		main = Camera.main;
	}
	
	// Update is called once per frame
	void Update(){
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		currentY = Mathf.Clamp (currentY, Y_Angle_Min, Y_Angle_Max);
	}
	void LateUpdate () {
		dir = new Vector3 (0, 0, -distance);
		rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
