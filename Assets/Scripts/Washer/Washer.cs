using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washer : MonoBehaviour
{
    public int cycle;
    public int load;
    public StateMachine<Washer> stateMachine;
    public Text currentState;

    void Awake()
    {
        State<Washer> initialState = new WashingState();
        StartState(initialState);
    }
    
    public void StartState(State<Washer> initialState)
    {
        // initialize FSM
        stateMachine = new StateMachine<Washer>();
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
    }
}
