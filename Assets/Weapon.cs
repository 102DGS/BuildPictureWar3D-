using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mouth;
    public PlaceForPictures pFP;
    int i = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && pFP.isActiveAndEnabled)
        {
            Shoot(pFP.randomColors[i], 5f);
            i = (i + 1) % pFP.randomColors.Length;
        }
    }

    void Shoot(Color color,float speed)
    {
        var bulletInstance = Instantiate(bullet, mouth.transform.position, mouth.transform.rotation) ;
        bulletInstance.GetComponent<Bullet>()._color = color;
        bulletInstance.GetComponent<Bullet>()._speed = speed;
    }
}
