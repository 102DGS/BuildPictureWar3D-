using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StaticClass
{
    public static Color[] imageByteArray(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageData);
        Color[] pix = tex.GetPixels();
        return pix;
    } 
}
