using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed, rotateSpeed, jumpForce;
    private Rigidbody rb;
    //GroundCheck Var
    private bool isGrounded;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    //---------------


    private void Start()
    {
        //GetComponent
        rb = GetComponent<Rigidbody>();
        //------------
    }

    private void Update()
    {
        //Do it all time
        Move();
        GroundCheck();
        //--------------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//Jump input check
        {
            Jump();//Jump
        }
    }
    private void FixedUpdate()
    {
    }

    private void Move()//Player movement function
    {
        Vector3 moveDir = new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir.Normalize();
        rb.MovePosition(rb.position + moveDir*walkSpeed*Time.deltaTime);

        if (moveDir != Vector3.zero)//Rotate character to face move direction
        {
            Quaternion rotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
        }
    }

    private bool GroundCheck()//GroundCheck function for jump(return bool)
    {
        isGrounded = Physics.CheckSphere(groundCheckPosition.position, groundCheckDistance, groundMask);
        return isGrounded;
    }
    private void Jump()//Player jump function
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//just add force can tweak force in inspector
    }
}