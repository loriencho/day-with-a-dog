using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string DogName { get; private set; }

    public static void setDogName(string dogName){
        DogName = dogName; 
    }

    public void restartGame(){
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene("Menu");

    }
}
