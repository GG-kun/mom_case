using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreState : State<Child>
{

    public override void Enter(Child entity){
        this.time = 3;
    }

    public override void Execute(Child entity){
        entity.currentState.text = "Shopping";
        this.time -= Time.deltaTime;
    }

    public override void Exit(Child entity, Mom mom){
        entity.currentState.text = "Finish Shopping";
        mom.AddActivity(new OccupiedState(0.5f, 2, "Receiving chilg"));
    }
}
