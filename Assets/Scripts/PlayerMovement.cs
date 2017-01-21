using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float jumpForce = 10f;
    float hori;
    float hori2;
    float vert;
    float m_speed;
    float groundCheckDistance = 0.2f;
    float originalGroundCheckDistance;

    bool isGrounded;
    bool settingLandBool;
    bool horiPressed;
    bool hori2Pressed;
    bool vertPressed;

    Animator anim;
    Rigidbody rb;
    KeyCode jumpButton;
    string horizontalAxis;
    string horizontalAxis2;
    string verticalAxis;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        originalGroundCheckDistance = groundCheckDistance;
        m_speed = speed;

        if (gameObject.name == "PlayerOne")
        {
            horizontalAxis = "PlayerOneHorizontal";
            horizontalAxis2 = "PlayerOneHorizontal2";
            verticalAxis = "PlayerOneVertical";
            jumpButton = KeyCode.Joystick1Button0;
        }
        else if (gameObject.name == "PlayerTwo")
        {
            horizontalAxis = "PlayerTwoHorizontal";
            horizontalAxis2 = "PlayerTwoHorizontal2";
            verticalAxis = "PlayerTwoVertical";
            jumpButton = KeyCode.Joystick2Button0;
        }
    }

    void FixedUpdate()
    {

        hori = Input.GetAxis(horizontalAxis);
        vert = Input.GetAxis(verticalAxis);
        hori2 = Input.GetAxis(horizontalAxis2);

        CheckGroundedStatus();

        if (isGrounded)
        {
            anim.SetFloat("Horizontal", hori);
            anim.SetFloat("Vertical", vert);
        }

        if (Input.GetKeyDown(jumpButton) && isGrounded)
        {
            anim.SetBool("isJumping", true);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            CheckGroundedStatus();
        }

        if (hori != 0)
            horiPressed = true;
        else
            horiPressed = false;

        if (hori2 != 0)
            hori2Pressed = true;
        else
            hori2Pressed = false;

        if (vert != 0)
            vertPressed = true;
        else
            vertPressed = false;

        if (horiPressed && vertPressed)
            m_speed = speed / speed;
        else
            m_speed = speed;

        if (!isGrounded)
            m_speed = speed * 0.75f;
        else
            m_speed = speed;

        transform.Translate(new Vector3(hori * Time.deltaTime * m_speed, 0f, vert * Time.deltaTime * m_speed));
        transform.Rotate(new Vector3(0, hori2 * Time.deltaTime * rotationSpeed, 0));
    }

    void CheckGroundedStatus()
    {
        RaycastHit hitInfo;
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.2f) + (Vector3.down * groundCheckDistance));
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo))
        {
            if ((hitInfo.collider.tag == "Ground" || hitInfo.collider.tag == "Ring" || hitInfo.collider.tag == "Environment") && hitInfo.distance <= groundCheckDistance)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                anim.SetBool("isJumping", false);
                anim.SetFloat("Height", hitInfo.distance);
            }
        }
    }
}