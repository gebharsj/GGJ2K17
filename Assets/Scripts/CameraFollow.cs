using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 100;
    public float cameraSpeed;
    public Vector3 cameraOffset;
    string horizontalAxis2;
    float hori2;

    void Start ()
    {
        if (gameObject.name == "PlayerOne")
        {
            horizontalAxis2 = "PlayerOneHorizontal2";
        }
        else if (gameObject.name == "PlayerTwo")
        {
            horizontalAxis2 = "PlayerTwoHorizontal2";
        }
    }
	void FixedUpdate ()
    {

        hori2 = Input.GetAxis(horizontalAxis2);

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + cameraOffset.x, player.transform.position.y + cameraOffset.y, player.transform.position.z + cameraOffset.z), Time.deltaTime * cameraSpeed);
        transform.Rotate(new Vector3(0, hori2 * Time.deltaTime * rotationSpeed, 0));
    }
}
