using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    private float groundDistance = 0.499f;
    private LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    void Start()
    {
        groundMask = 4096 | 256;
    }

    
    void Update()
    {
        Run();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetButtonDown("Jump") && isGrounded) Jump();
        if (!isGrounded) FreeFall();        
    }
    private void Run()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        controller.Move(velocity * Time.deltaTime);
    }
    private void FreeFall()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, 0.49f);
    }*/
}
