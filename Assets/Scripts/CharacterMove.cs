using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private float speed = 5f;
    private float jumpForce = 10f;
    private Rigidbody _rigidbody;

    private Vector3 checkGroundSize = new Vector3(1f, 0.0001f, 1f);

    private bool isGrounded;
    private LayerMask groundMask; 


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        groundMask = 256;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Run();
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log(isGrounded);
        }

        isGrounded = Physics.CheckBox(transform.position, checkGroundSize, transform.rotation, groundMask);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Run()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * x + transform.forward * z;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, checkGroundSize);
    }
}
