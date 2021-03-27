using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingState : State<Stove>
{
    public override bool IsValid(Stove entity)
    {
        return entity.food != null;
    }
    public override void Enter(Stove entity, Mom mom){
        this.time = entity.food.time;
        entity.currentState.text += "\n" + "Cooking";
    }

    public override void Execute(Stove entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Stove entity, Mom mom){
        entity.currentState.text += "\n" + "Finish Cooking";
        entity.food.isCooked = true;
        mom.AddActivity(new OccupiedState(entity.exitTime, entity.priority, 4, "Taking food out"));
    }
}
