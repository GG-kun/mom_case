using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washer : MonoBehaviour
{
    public int cycle;
    public int load;
    public StateMachine<Washer> stateMachine = new StateMachine<Washer>();
    public Text currentState;
    
    public float entryTime = 1, time = 6, exitTime = 2;
    public int priority = 1;
    
    public void StartState(State<Washer> initialState)
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
