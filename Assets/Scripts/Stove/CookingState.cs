using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingState : State<Stove>
{
    public override void Enter(Stove entity){
        this.time = entity.food.time;
    }

    public override void Execute(Stove entity){
        entity.currentState.text = "Cooking";
        this.time -= Time.deltaTime;
    }

    public override void Exit(Stove entity, Mom mom){
        entity.currentState.text = "Finish Cooking";
        mom.AddActivity(new OccupiedState(1, 0, "Taking food out"));
    }
}
