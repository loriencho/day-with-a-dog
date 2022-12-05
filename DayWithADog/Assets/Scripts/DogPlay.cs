using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DogPlay : DogAction
{
    public override void Act(){
        GameObject toy = GameObject.Find(actionItemName);
        GameObject dog = GameObject.Find("Dog");
        toy.transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y, dog.transform.position.z);
    }
}
