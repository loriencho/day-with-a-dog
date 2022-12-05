using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DogEat : DogAction
{
    public override void Act(){
        GameObject food = GameObject.Find(actionItemName);
        GameObject dog = GameObject.Find("Dog");
        food.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y - 1f, dog.transform.position.z);
    }
}
