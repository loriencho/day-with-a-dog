using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private const int Left = 2;

    void Start(){
        behaviorState = BehaviorState.Idle;
        idleMoving = true; 
        movingDirection = Random.Range(1, 3);
        StartCoroutine(Behave());
    }

    private void setRandomIdle(){
        float chance = Random.Range(0, 100);
        if (chance < 25){ // 75% chance it'll continue its current action, 25% chance it'll change
            idleMoving = !idleMoving;
        }

    }

    private void Idle(){
        if (idleMoving){
            if (transform.position.x >= 320){
                movingDirection = Left;
            }
            else if (transform.position.x <= -320){
                movingDirection = Right;
            }
        }
    }

    IEnumerator Behave(){
        if (behaviorState == BehaviorState.Idle){
            setRandomIdle();
            Idle();
        }
        yield return null;

    }       
    
}
