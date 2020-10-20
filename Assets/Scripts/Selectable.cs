using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : UseableObjects
{ 
    protected Rigidbody _rigidbody;


    public abstract void Select(Transform transform);

    public abstract void Deselect();
   

    
}

