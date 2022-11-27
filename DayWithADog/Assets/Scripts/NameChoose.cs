using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChoose : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;
    public void setDogNameToInput(){
        GameManager.setDogName(inputField.text);
    }
}
