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
    public OccupiedState(float time, int priority, int nextState, List<Text> stateTexts, string occupiedMessage){
        this.time = time;
        this.priority = priority;
        this.nextState = nextState;
        this.stateTexts = stateTexts;
        this.occupiedMessage = occupiedMessage;
    }

    public OccupiedState(float time, int priority, string occupiedMessage){
        this.time = time;
        this.priority = priority;
        this.occupiedMessage = occupiedMessage;
    }


    public override void Enter(Mom entity){
        entity.currentState.text = occupiedMessage;
    }

    public override void Execute(Mom entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Mom entity, Mom mom){
        entity.currentState.text = "Unoccupied";
        
        GameObject temp = new GameObject();
        switch (nextState)
        {
            case 0:
                temp.name = "Child";
                Child child = temp.AddComponent<Child>();
                child.stateMachine.mom = entity;
                child.currentState = stateTexts[nextState];
                break;
            case 1:
                temp.name = "Stove";
                Stove stove = temp.AddComponent<Stove>();
                stove.stateMachine.mom = entity;
                stove.currentState = stateTexts[nextState];
                break;
            case 2:
                temp.name = "Washer";
                Washer washer = temp.AddComponent<Washer>();
                washer.stateMachine.mom = entity;
                washer.currentState = stateTexts[nextState];
                break;
            default:
                temp.SetActive(false);
                break;
        }
    }
}
