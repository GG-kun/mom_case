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

    public override bool IsValid(Mom entity)
    {
        string[] lines = entity.currentState.text.Split('\n');
        string lastLine = lines[lines.Length-1];
        string currentLine = "";
        switch (nextState)
        {
            case 0:
                currentLine = "Checking Child";
                if(lastLine != currentLine){
                    entity.currentState.text += "\n" + currentLine;
                }

                entity.child.money += entity.money;
                entity.money = 0;
                StoreState storeState = new StoreState();
                if(storeState.IsValid(entity.child)){
                    entity.child.currentState.text += "\nReady";
                    return true;
                }
                break;
            case 1:
                currentLine = "Checking Stove";
                if(lastLine != currentLine){
                    entity.currentState.text += "\n" + currentLine;
                }

                entity.stove.food = entity.food;
                CookingState cookingState = new CookingState();
                if(cookingState.IsValid(entity.stove)){
                    entity.stove.currentState.text += "\nReady";
                    return true;
                }
                break;
            case 2:
                currentLine = "Checking Washer";
                if(lastLine != currentLine){
                    entity.currentState.text += "\n" + currentLine;
                }

                WashingState washingState = new WashingState();
                if(washingState.IsValid(entity.washer)){
                    entity.washer.currentState.text += "\nReady";
                    return true;
                }
                break;
            default:
                return true;
        }
        return false;
    }

    public override void Enter(Mom entity, Mom mom){
        entity.currentState.text += "\n" + occupiedMessage;
    }

    public override void Execute(Mom entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Mom entity, Mom mom){
        entity.currentState.text += "\n" + "Unoccupied";
        entity.stateMachine.CurrentState = null;
        
        switch (nextState)
        {
            case 0:
                entity.child.stateMachine.mom = entity;
                entity.child.StartState(new StoreState());
                break;
            case 1:
                entity.stove.stateMachine.mom = entity;
                entity.stove.StartState(new CookingState());
                break;
            case 2:
                entity.washer.stateMachine.mom = entity;
                entity.washer.StartState(new WashingState());
                break;
            case 3:            
                entity.food = entity.child.food;
                entity.child.food = null;
                entity.money += entity.child.money;
                entity.child.money = 0;
                break;
            case 4:
                entity.food = entity.stove.food;
                break;
            default:
                break;
        }
    }
}
