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
    bool canSprint = true;
    public bool isPoweredUp = false;
    Animator anim;
    Rigidbody rb;
    KeyCode jumpButton;
    string horizontalAxis;
    string horizontalAxis2;
    string verticalAxis;
    float originalJumpForce;
    KeyCode sprintButton;
    bool isStunned;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        originalJumpForce = jumpForce;
        originalGroundCheckDistance = groundCheckDistance;
        m_speed = speed;

        if (gameObject.name == "PlayerOne")
        {
            horizontalAxis = "PlayerOneHorizontal";
            horizontalAxis2 = "PlayerOneHorizontal2";
            verticalAxis = "PlayerOneVertical";
            jumpButton = KeyCode.Joystick1Button0;
            sprintButton = KeyCode.Joystick1Button8;
        }
        else if (gameObject.name == "PlayerTwo")
        {
            horizontalAxis = "PlayerTwoHorizontal";
            horizontalAxis2 = "PlayerTwoHorizontal2";
            verticalAxis = "PlayerTwoVertical";
            jumpButton = KeyCode.Joystick2Button0;
            sprintButton = KeyCode.Joystick2Button8;

        }
    }

    void Update()
    {

        hori = Input.GetAxis(horizontalAxis);
        vert = Input.GetAxis(verticalAxis);
        hori2 = Input.GetAxis(horizontalAxis2);

        CheckGroundedStatus();
        if(Input.GetKeyDown(sprintButton) && canSprint)
        {
            canSprint = false;
            StartCoroutine(Sprint());
        }

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

        if(!isStunned)
        {
            if (!isPoweredUp)
            {
                transform.Translate(new Vector3(hori * Time.deltaTime * m_speed, 0f, vert * Time.deltaTime * m_speed));
                transform.Rotate(new Vector3(0, hori2 * Time.deltaTime * rotationSpeed, 0));
            }
            else
            {
                transform.Translate(new Vector3(hori * Time.deltaTime * m_speed * 2, 0f, vert * Time.deltaTime * m_speed * 2));
                transform.Rotate(new Vector3(0, hori2 * Time.deltaTime * rotationSpeed * 2, 0));
            }
        }
        else
        {
            //Do Nothing
        }

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

    public IEnumerator PowerUp()
    {
        isPoweredUp = true;
        yield return new WaitForSeconds(15);
        isPoweredUp = false;
    }

    public IEnumerator Sprint()
    {
        isPoweredUp = true;
        yield return new WaitForSeconds(5);
        isPoweredUp = false;
        yield return new WaitForSeconds(5);
        canSprint = true;
    }

    public IEnumerator JumpPowerUp()
    {
        jumpForce *= 2;
        yield return new WaitForSeconds(15);
        jumpForce = originalJumpForce;
    }

    public IEnumerator Stun()
    {
        if(!isStunned)
        {
            isStunned = true;
            yield return new WaitForSeconds(0.5f);
            isStunned = false;
        }
        yield return new WaitForSeconds(0.5f);
        isStunned = false;
    }
}