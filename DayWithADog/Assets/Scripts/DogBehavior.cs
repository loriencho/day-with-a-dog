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

    private BehaviorState state;

    void Start(){

        state = BehaviorState.Idle;
    }

    void Update(){
        switch(state){
            case BehaviorState.Idle:
            
            break;

        }

    }        
    
}
