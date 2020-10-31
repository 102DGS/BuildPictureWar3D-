using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : Button
{
    public Canvas canvas;
    public PlaceForPictures pFP;
    public Weapon weapon;

    public override void OnPressed()
    {
        canvas.gameObject.SetActive(true);
        pFP.gameObject.SetActive(true);
        Pressed = true;
        ButtonAnimation();
        weapon.ChangeColor();
    }
}
