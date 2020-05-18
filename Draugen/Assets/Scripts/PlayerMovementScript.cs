using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementScript : MonoBehaviour
{


    [SerializeField] private AudioSource footSteps;
    [SerializeField] private float speed;
    [SerializeField] private float sprintMod;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask ground;
    [SerializeField] Transform groundDetector;
    CharacterController cc;
    private Rigidbody rb;


    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        Camera.main.enabled = false;
        cc.GetComponent<CharacterController>();
        
    }

   

    private void FixedUpdate()
    {

        float Hmovement = Input.GetAxisRaw("Horizontal");
        float Vmovement = Input.GetAxisRaw("Vertical");
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && isGrounded;

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        Vector3 NewMove = new Vector3(Hmovement, 0, Vmovement);
        NewMove.Normalize();

        float AdjustedSpeed = speed;
        if (isSprinting) AdjustedSpeed *= sprintMod;

        Vector3 targetVelocity = transform.TransformDirection(NewMove) * AdjustedSpeed * Time.deltaTime;
        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;

        if (Hmovement != 0 || Vmovement != 0 && isGrounded)
        {
            if (!footSteps.isPlaying)
            {
                footSteps.Play();
            }
        }

        if(!isGrounded)
        {
            footSteps.Stop();
        }
    }

    private void Update()
    {

        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);

        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;

        bool isSprinting = sprint && isGrounded;

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            footSteps.Stop();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            footSteps.Stop();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            footSteps.Stop();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            footSteps.Stop();
        }
    }
}
