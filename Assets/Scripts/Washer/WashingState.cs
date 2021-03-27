using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingState : State<Washer>
{
    public override bool IsValid(Washer entity)
    {
        return true;
    }
    public override void Enter(Washer entity, Mom mom){
        this.time = entity.time / entity.cycle;
        entity.currentState.text += "\n" + "Washing";
    }

    public override void Execute(Washer entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Washer entity, Mom mom){
        entity.currentState.text += "\n" + "Finish Washing";
        mom.AddActivity(new OccupiedState(entity.exitTime, entity.priority, "Unloading washer"));
    }
}
