using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{ 
    [SerializeField]
    public TextMeshProUGUI titleTMP;
    [SerializeField]
    public RectTransform backgroundRt; 
    
    public void SetPopup(Popup popup){
        titleTMP.text = popup.title;
        backgroundRt.sizeDelta = new Vector2(popup.height, popup.width);
    }
}
