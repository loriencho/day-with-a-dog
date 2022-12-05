using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActivityItem : MonoBehaviour
{
    [SerializeField]
    private RectTransform rt;
    [SerializeField]
    private Vector2 position;
    [SerializeField] 
    private string room;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Button button;

    void Start(){
        rt.anchoredPosition = position;     
    }

    private void setFaded(bool faded){
        if (!faded){
            button.interactable = true;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 255f / 255f);
        }
        else{
            button.interactable = false;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 115f / 255f);
        }
    }

    public void updateFadedStatus(){
        if (BackgroundController.Background.Equals(room))
            setFaded(false);
        else   
            setFaded(true);
    }
}

