using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HelpTool
{
    public static LayerMask selectableLayerMask = 512;
    public static Color[] imageToByteArray(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageData);
        Color[] pix = tex.GetPixels();
        //Пиксели с картинки считаются снизу вверх справ влево , те элемент на нулевой позиции будет левым нижним , на второй правее от него
        return (pix);
    } 
}
