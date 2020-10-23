using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Color _color;
    public float _speed;
    Rigidbody _rigidbody;
    Renderer _renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _color;
        _rigidbody.AddForce(transform.forward * _speed);
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var Cube = collision.gameObject.GetComponent<Cube>();
        if (Cube)
        {
            Cube.ChangeColor(_color);
            Destroy(gameObject);
        }
    }
}
