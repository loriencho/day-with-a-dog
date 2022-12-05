using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogAction : ScriptableObject
{
    public string actionItemName;

    public abstract void Act();
}
