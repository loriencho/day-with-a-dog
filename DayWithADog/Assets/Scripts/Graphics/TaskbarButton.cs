using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskbarButton : MonoBehaviour
{
    [SerializeField]
    private GameObject dropdown;

    private bool dropdownOpened = false;

    public void flipButtonVertical(){
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

    public void toggleDropdownOpened(){
        dropdownOpened = !dropdownOpened;
        dropdown.SetActive(dropdownOpened);
    }
}
