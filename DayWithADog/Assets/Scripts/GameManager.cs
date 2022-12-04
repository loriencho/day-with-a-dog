using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string DogName { get; private set; }
    public static string Background { get; private set; }

    public static void setDogName(string dogName){
        DogName = dogName; 
    }

    public static void changeLocation(string background){
        Background = background; 
    }

}
