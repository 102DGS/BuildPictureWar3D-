using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float speed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveBy = transform.right * x + transform.forward * z;
        _rigidbody.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

        /*if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(transform.right * -speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(transform.forward * -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(transform.right * speed);
        }*/

        /*float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        _rigidbody.velocity = new Vector3(xMov, _rigidbody.velocity.y, zMov) * speed * Time.deltaTime;*/
    }
}
