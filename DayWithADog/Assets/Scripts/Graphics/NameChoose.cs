using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChoose : MonoBehaviour
{
    private static string _dogName;
    public static string DogName { get{return _dogName; } }

    [SerializeField]
    public TMP_InputField inputField;
    
    public void setDogNameToInput(){
        _dogName = inputField.text;
    }
}
