using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBehavior : MonoBehaviour {
    //Components
    [SerializeField]
    private RectTransform rt;
    [SerializeField]
    private Image image;

    // Sprites
    [SerializeField]
    private List<Sprite> _sprites;
    private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    // Action/Task Logic
    [SerializeField]
    private List<DogAction> dogActionsToDo;
    [SerializeField]
    private GameEvent allActionsDone;

    //Movement configuration
    private bool isIdle;
    private bool idleMoving;
    private Directions movingDirection;

    enum Directions{
        Right = 1,
        Left = -1
    }

    // Setup movement, sprites
    void Start(){
        isIdle = true;
        idleMoving = true; 
        movingDirection = Directions.Right;

        for (int i = 0; i< _sprites.Count; i++){
            sprites.Add(_sprites[i].name, _sprites[i]);
        }
    }

    // Sitting / moving randomization
    private void setRandomIdle(int chance){
        float random = Random.Range(0, 100);
        if (random < chance){ 
            idleMoving = !idleMoving;
        }
    }

    private void Idle(){
        if (idleMoving){
            // Running 

            image.sprite = sprites["dog_play"];  
            if (rt.anchoredPosition.x >= 320f){ // Right edge of screen
                setRandomIdle(50);

                movingDirection = Directions.Left;
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (rt.anchoredPosition.x == 0){ //Center
                setRandomIdle(50); 
            }
            else if (rt.anchoredPosition.x  <= -320f){ // Left edge of screen
                setRandomIdle(50);

                movingDirection = Directions.Right;
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + (2f * (int)movingDirection), -150f);
        }
        else{
            // Sitting 
            image.sprite = sprites["dog_idle"];

            setRandomIdle(5); 
        }
    }

    void FixedUpdate(){
        if (isIdle){ // not doing action
            Idle();
        }
    }       

    public void Act(DogAction dogAction){
        // Stop idling action
        isIdle = false;
        image.sprite = sprites["dog_idle"];

        // Start activity action
        dogAction.Act();
        StartCoroutine(FinishDogAction(dogAction));
    }

    IEnumerator FinishDogAction(DogAction dogAction){
        GameObject actionItem = GameObject.Find(dogAction.actionItemName); // before to prevent removal lag

        yield return new WaitForSeconds(2f);

        // Resume idling, remove activity item from scene
        isIdle = true;
        actionItem.SetActive(false);
        
        // check if all tasks complete
        dogActionsToDo.Remove(dogAction);
        if(dogActionsToDo.Count == 0){
            allActionsDone.Raise();
        }
    }
    
}
