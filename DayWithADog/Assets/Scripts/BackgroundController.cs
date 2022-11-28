using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private List<Sprite> _backgrounds; 
    private Dictionary<string, Sprite> backgrounds = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {  
        for (int i = 0; i< _backgrounds.Count; i++){
            backgrounds.Add(_backgrounds[i].name, _backgrounds[i]);
        }

        // setBackground("Kitchen");
    
    }

    public void setBackground(string backgroundName){
        backgroundImage.sprite = backgrounds[backgroundName];
    }

}
