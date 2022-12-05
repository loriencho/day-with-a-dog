using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    [SerializeField]
    private List<GameEvent> _gameEvents; 


    private Dictionary<string, GameEvent> gameEvents = new Dictionary<string, GameEvent>();

    // Start is called before the first frame update
    void Start()
    {  
        for (int i = 0; i< _gameEvents.Count; i++){
            gameEvents.Add(_gameEvents[i].name, _gameEvents[i]);
        }
        gameEvents["StartNameChoose"].Raise();
    
    }

    public void RaiseEvent(string eventName){
        gameEvents[eventName].Raise();

    }
}
