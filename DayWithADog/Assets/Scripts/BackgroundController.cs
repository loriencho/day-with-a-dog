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

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {  
        for (int i = 0; i< _backgrounds.Count; i++){
            backgrounds.Add(_backgrounds[i].name, _backgrounds[i]);
        }

        setBackgroundString("bg");
    
    }

    public void setBackgroundString(string backgroundName){
        backgroundImage.sprite = backgrounds[backgroundName];
    }

    public void increaseBackground(){
        index = ( index + 1 ) % (_backgrounds.Count-1);
        backgroundImage.sprite = _backgrounds[index];
        GameManager.changeLocation(backgroundImage.sprite.name);

    }

    public void decreaseBackground(){
        index = ( index - 1 ) % (_backgrounds.Count - 1);
        if (index < 0)
            index = _backgrounds.Count - 2;
        backgroundImage.sprite = _backgrounds[index];
        GameManager.changeLocation(backgroundImage.sprite.name);

    }
}
