using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Child : MonoBehaviour
{
    public Food food;
    public float money;
    public StateMachine<Child> stateMachine;
    public Text currentState;
    void Awake()
    {
        State<Child> initialState = new StoreState();
        StartState(initialState);
    }
    
    public void StartState(State<Child> initialState)
    {
        // initialize FSM
        stateMachine = new StateMachine<Child>();
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
    }
}
