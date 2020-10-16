using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlocks : MonoBehaviour
{
    public PlaceForPictures pFP;
    public Cube cube;

    public Cube[] randomCubes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int index = Random.Range(0, 3);
            Cube newCube = Instantiate(randomCubes[index], transform.position, transform.rotation);
        }
    }
}
