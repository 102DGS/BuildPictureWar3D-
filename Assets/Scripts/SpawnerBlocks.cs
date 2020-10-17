using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnerBlocks : MonoBehaviour
{
    public PlaceForPictures pFP;
    private int cubeIndex = 0;

    private bool isGenerated = false;

    public Cube cube;

    private float timeForSpawn = 0f;
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
        if (Input.GetKeyDown(KeyCode.Q) && cubeIndex < pFP.colors.Length)
        {
            if (!isGenerated)
            {
                isGenerated = true;
                Shuffle();
            }
            cube.gameObject.GetComponent<Renderer>().sharedMaterial.color = pFP.colors[randomCubes[cubeIndex]];
            Cube newCube = Instantiate(cube, transform.position, transform.rotation);
            cubeIndex++;

            timeForSpawn = 1f;
        }

        timeForSpawn -= Time.deltaTime;
    }
}
