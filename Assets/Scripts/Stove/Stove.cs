using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stove : MonoBehaviour
{
    public Food food;
    public int heat;
    public StateMachine<Stove> stateMachine = new StateMachine<Stove>();
    public Text currentState;
    
    public float entryTime = 1, time = 3, exitTime = 1;
    public int priority = 0;
    
    public void StartState(State<Stove> initialState)
    {
        // initialize FSM
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
    }
}
