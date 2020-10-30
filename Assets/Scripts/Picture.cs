using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Picture 
{
    static public Color neutralColor = Color.white;
    public Color[] colors;
    public Color[] shufflingColors;
    public Color[] setColors;
    public int width;
    public int height;

    public Picture(int imgNumber)
    {
        colors = HelpTool.imageToByteArray(Application.dataPath + "/Pictures/" + "Test/" + imgNumber + ".png",out height, out width);
        shufflingColors = shufflingColor();
        setColors = shufflingColors.Distinct().Where(x => x != neutralColor).ToArray(); ;
    }


    public static int currentPictures = HelpTool.numberOfPngInDirectory(Application.dataPath + "/Pictures/" + "Test/");
    private Color[] shufflingColor()
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < colors.Length)
        {
            numbers.Add(Random.Range(0, colors.Length));
        }
        int[] randomCubes = numbers.ToArray<int>();
        Color[] shuffelingColor = new Color[randomCubes.Length];
        for(int i = 0;i< shuffelingColor.Length; i++)
        {
            shuffelingColor[i] = colors[randomCubes[i]];
        }
        return shuffelingColor;
    }

}