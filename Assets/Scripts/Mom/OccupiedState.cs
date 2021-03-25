using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OccupiedState : State<Mom>
{
    public List<Text> stateTexts;
    public int priority = -1;
    public int nextState = -1;
    public string occupiedMessage = "Occupied";
    public OccupiedState(float time, int priority, int nextState, string occupiedMessage){
        this.time = time;
        this.priority = priority;
        this.nextState = nextState;
        this.occupiedMessage = occupiedMessage;
    }

    public OccupiedState(float time, int priority, string occupiedMessage){
        this.time = time;
        this.priority = priority;
        this.occupiedMessage = occupiedMessage;
    }


    public override void Enter(Mom entity){
        entity.currentState.text += "\n" + occupiedMessage;
    }

    public override void Execute(Mom entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Mom entity, Mom mom){
        entity.currentState.text += "\n" + "Unoccupied";
        
        switch (nextState)
        {
            case 0:
                entity.child.StartState(new StoreState());
                entity.child.stateMachine.mom = entity;
                break;
            case 1:
                entity.stove.StartState(new CookingState());
                entity.stove.stateMachine.mom = entity;
                break;
            case 2:
                entity.washer.StartState(new WashingState());
                entity.washer.stateMachine.mom = entity;
                break;
            default:
                break;
        }
    }
}
