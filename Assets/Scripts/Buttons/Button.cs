using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    protected float speed = 0.1f;
    protected Vector3 direction = new Vector3(-0.01f, 0f, 0f);

    public bool Pressed { get; set; } = false;
    protected Vector3 finishPosition;
    protected Vector3 startPosition;

    protected void Awake()
    {
        startPosition = transform.position;
        finishPosition = transform.position - new Vector3(0.05f, 0f, 0f);
    }

    public void ButtonAnimation()
    {
        GetComponent<Animator>().Play("ButtonAnimation", -1, 0f);
    }

    public abstract void OnPressed();
}
