using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRayForward : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Awake()
    {
        Debug.DrawRay(transform.position,transform.forward*100,Color.yellow);
       

    }
}
