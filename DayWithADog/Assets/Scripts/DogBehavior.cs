using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBehavior : MonoBehaviour
{
    enum BehaviorState{
        Idle = 1,
        Comb = 2,
        Feed = 3,
        Play = 4
    }

    private int numIdleActions;
    private BehaviorState behaviorState;
    private bool idleMoving;
    private int movingDirection;
    private const int Right = 1;
    private const int Left = -1;
    [SerializeField]
    private RectTransform rt;
    [SerializeField]
    private Image image;
    [SerializeField]
    private List<Sprite> _sprites;
    private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    void Start(){
        behaviorState = BehaviorState.Idle;
        idleMoving = true; 
        movingDirection = Random.Range(1, 3);
        for (int i = 0; i< _sprites.Count; i++){
            sprites.Add(_sprites[i].name, _sprites[i]);
        }
    }

    private void setRandomIdle(int chance){
        float random = Random.Range(0, 100);
        if (random < chance){ 
            idleMoving = !idleMoving;
        }

    }

    private void Idle(){
        if (idleMoving){
                image.sprite = sprites["dog_play"];
            if (rt.anchoredPosition.x >= 320f){
                movingDirection = Left;
                setRandomIdle(50);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (rt.anchoredPosition.x  <= -320f){
                movingDirection = Right;
                setRandomIdle(50);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);


            }
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + (2f * movingDirection), -150f);
        }
        else{
            image.sprite = sprites["dog_idle"];
            setRandomIdle(5);
   
        }
    }

    void FixedUpdate(){

        if (behaviorState == BehaviorState.Idle){
            Idle();
        }

    }       
    
}
