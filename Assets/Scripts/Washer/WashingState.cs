using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingState : State<Washer>
{
    public override void Enter(Washer entity){
        this.time = 6;
    }

    public override void Execute(Washer entity){
        entity.currentState.text = "Whasing";
        this.time -= Time.deltaTime;
    }

    public override void Exit(Washer entity, Mom mom){
        entity.currentState.text = "Finish Whasing";
        mom.AddActivity(new OccupiedState(2, 1, "Unloading washer"));
    }
}
