using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlocks : MonoBehaviour
{
    public PlaceForPictures pFP;
    private int cubeIndex = 0;

    public Cube cube;

    private float timeForSpawn = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cubeIndex < pFP.colors.Length)
        {
            cube.gameObject.GetComponent<Renderer>().sharedMaterial.color = pFP.colors[cubeIndex];
            Cube newCube = Instantiate(cube, transform.position, transform.rotation);
            cubeIndex++;

            timeForSpawn = 1f;
        }

        timeForSpawn -= Time.deltaTime;
    }
}
