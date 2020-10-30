using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    Renderer _renderer;
    public GameObject mouth;
    public PlaceForPictures pFP;
    int i = 0;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && pFP.gameObject.activeSelf)
        {
            Shoot(pFP.randomColors[i], 5f);
            i = (i + 1) % pFP.randomColors.Length;
            _renderer.material.color = pFP.randomColors[i];
        }
    }

    void Shoot(Color color,float speed)
    {
        var bulletInstance = Instantiate(bullet, mouth.transform.position, mouth.transform.rotation) ;
        bulletInstance.GetComponent<Bullet>()._color = color;
        bulletInstance.GetComponent<Bullet>()._speed = speed;
    }
}
