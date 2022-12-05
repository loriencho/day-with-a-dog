using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TMP;

    void OnEnable(){
        TMP.text = NameChoose.DogName;        
    }
}
