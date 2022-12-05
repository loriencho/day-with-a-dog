using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DogGroom : DogAction
{
    public override void Act(){
        GameObject comb = GameObject.Find(actionItemName);
        GameObject dog = GameObject.Find("Dog");
        comb.transform.position = new Vector3(dog.transform.position.x + 1f, dog.transform.position.y, dog.transform.position.z);
    }
}
