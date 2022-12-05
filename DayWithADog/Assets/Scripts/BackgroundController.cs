using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    // General assets / Components
    [SerializeField]
    GameEvent changeLocationEvent;
    [SerializeField]
    private Image backgroundImage;

    // Background assets
    [SerializeField]
    private List<Sprite> _backgrounds; 
    private Dictionary<string, Sprite> backgrounds = new Dictionary<string, Sprite>();

    // Properties
    private static string _background;
    public static string Background {get {return _background;}}
    public int index;

    // Setup bg dictionary and initial bg
    void Start()
    {  
        for (int i = 0; i< _backgrounds.Count; i++){
            backgrounds.Add(_backgrounds[i].name, _backgrounds[i]);
        }
        setBackgroundString("bg");  
    }

    // Update information and scene
    private void updateLocation(){
        _background = backgroundImage.sprite.name;
        changeLocationEvent.Raise();    
    }

    // Background setter
    public void setBackgroundString(string backgroundName){
        backgroundImage.sprite = backgrounds[backgroundName];
        index = _backgrounds.IndexOf(backgroundImage.sprite);

        updateLocation();
    }


    // Navigation

    public void increaseBackground(){
        index = ( index + 1 ) % (_backgrounds.Count-1);
        backgroundImage.sprite = _backgrounds[index];
        
        updateLocation();
    }

    public void decreaseBackground(){
        index = ( index - 1 ) % (_backgrounds.Count - 1);
        if (index < 0)
            index = _backgrounds.Count - 2;
        backgroundImage.sprite = _backgrounds[index];

        updateLocation();
    }
}
