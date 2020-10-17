using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlocks : MonoBehaviour
{
    public PlaceForPictures pFP;
    public Cube cube;

    private float timeForSpawn = 0f;

    public Cube[] randomCubes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && timeForSpawn <= 0f)
        {
            int index = Random.Range(0, 3);
            Cube newCube = Instantiate(randomCubes[index], transform.position, transform.rotation);

            timeForSpawn = 1f;
        }

        timeForSpawn -= Time.deltaTime;
    }
}
