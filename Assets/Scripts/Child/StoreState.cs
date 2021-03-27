using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreState : State<Child>
{

    public override bool IsValid(Child entity)
    {
        return entity.money > 0;
    }

    public override void Enter(Child entity, Mom mom){
        this.time = entity.time;
        entity.currentState.text += "\n" + "Shopping";
    }

    public override void Execute(Child entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Child entity, Mom mom){
        entity.currentState.text += "\n" + "Finish Shopping";
        entity.BuyFood();
        mom.AddActivity(new OccupiedState(entity.exitTime, entity.priority, 3, "Receiving child"));
    }
}
