using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceForPicture : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Cube cube = collider.GetComponent<Cube>();

        if (cube.gameObject.layer == 10)
        {
            Debug.Log("It works!");
            cube.CurrentRotation = Quaternion.Euler(0f, 0f, 0f);
            cube.CurrentPosition = transform.position + new Vector3(0f, 2f, 0f);
            cube.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
