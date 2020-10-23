using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateWithMouse : MonoBehaviour
{
    private float speed = 3f;
    void Update()
    {
        float xMov = Input.GetAxis("Mouse X");

        transform.Rotate(xMov * speed * Vector3.up, Space.World);
    }
}
