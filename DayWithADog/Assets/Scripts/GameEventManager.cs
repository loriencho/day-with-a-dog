using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log(gameEvents);
        foreach (KeyValuePair<string, GameEvent> kvp in gameEvents)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            Debug.Log("Key = " + kvp.Key + "Value = " + kvp.Value);
        }
        gameEvents["StartNameChoose"].Raise();
    
    }

    public void RaiseEvent(string eventName){
        gameEvents[eventName].Raise();

    }

}
