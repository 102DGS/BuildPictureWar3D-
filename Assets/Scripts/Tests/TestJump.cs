using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    private float jumpForce = 500f;
    private bool _shouldJump;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_shouldJump)
        {
            _shouldJump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void FixedUpdate()
    {
        if (_shouldJump)
        {
            _rigidbody.AddForce(transform.up * jumpForce);
            _shouldJump = !_shouldJump;
        }
    }
}