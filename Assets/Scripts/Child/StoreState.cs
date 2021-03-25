using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreState : State<Child>
{

    public override void Enter(Child entity){
        this.time = entity.entryTime;
        entity.currentState.text += "\n" + "Shopping";
    }

    public override void Execute(Child entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Child entity, Mom mom){
        entity.currentState.text += "\n" + "Finish Shopping";
        mom.AddActivity(new OccupiedState(entity.exitTime, entity.priority, "Receiving child"));
    }
}
