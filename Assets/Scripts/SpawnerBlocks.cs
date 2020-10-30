using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnerBlocks : MonoBehaviour
{
    public PlaceForPictures pFP;
    private int cubeIndex = 0;


    public Cube cube;

    private int[] randomCubes;

    private void Shuffle()
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < pFP.colors.Length)
        {
            numbers.Add(Random.Range(0, pFP.colors.Length));
        }
        randomCubes = numbers.ToArray<int>();

        Debug.Log(randomCubes.Length);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cubeIndex < pFP.randomColors.Length)
        {

            Cube newCube = Instantiate(cube, transform.position, transform.rotation);

            newCube.gameObject.GetComponent<Renderer>().material.color = pFP.randomColors[cubeIndex];
            cubeIndex++;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            Cube newCube = Instantiate(cube, transform.position, transform.rotation);

        }

    }
}
