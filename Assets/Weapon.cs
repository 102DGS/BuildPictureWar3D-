using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mouth;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) Shoot(Color.red,5f);
    }

    void Shoot(Color color,float speed)
    {
        var bulletInstance = Instantiate(bullet, mouth.transform.position, mouth.transform.rotation) ;
        bulletInstance.GetComponent<Bullet>()._color = color;
        bulletInstance.GetComponent<Bullet>()._speed = speed;
    }
}
