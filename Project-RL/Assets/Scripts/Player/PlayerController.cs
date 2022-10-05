using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed, rotateSpeed, jumpForce;
    private Rigidbody rb;
    [SerializeField] Camera cam;
    //GroundCheck Var
    private bool isGrounded;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    //---------------
    //Animaion
    public Animator animator;
    //--------
    private void Start()
    {
        //GetComponent
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //------------
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//Jump input check
        {
            Jump();//Jump
        }
        
        Aim();
    }
    private void FixedUpdate()
    {
        //Do it all time
        Move();
        GroundCheck();
        //--------------
    }

    private void Move()//Player movement function
    {
        Vector3 moveDir = new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir.Normalize();
        rb.MovePosition(rb.position + moveDir * (walkSpeed + LevelManager.instance.bonusMoveSpeed) *Time.deltaTime);

        animator.SetFloat("MoveSpeed", moveDir.magnitude);        
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0f;
            transform.forward = direction;
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