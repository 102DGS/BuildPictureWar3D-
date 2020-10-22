using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        Vector3 oldPos = transform.position;
        Quaternion oldRot = transform.rotation;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity; 

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Mesh finalMesh = new Mesh();

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        Debug.Log(filters.Length);

        for (int i = 0;i< filters.Length; i++)
        {
            if (filters[i].transform == transform) continue;
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.position = oldPos;
        transform.rotation = oldRot;
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) CombineMeshes();
    }
}
