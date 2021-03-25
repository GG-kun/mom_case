using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingState : State<Washer>
{
    public override void Enter(Washer entity){
        this.time = entity.entryTime;
        entity.currentState.text += "\n" + "Whasing";
    }

    public override void Execute(Washer entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Washer entity, Mom mom){
        entity.currentState.text += "\n" + "Finish Whasing";
        mom.AddActivity(new OccupiedState(entity.exitTime, entity.priority, "Unloading washer"));
    }
}
