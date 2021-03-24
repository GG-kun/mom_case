using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stove : MonoBehaviour
{
    public Food food = new Food();
    public int heat;
    public StateMachine<Stove> stateMachine;
    public Text currentState;

    void Awake()
    {
        State<Stove> initialState = new CookingState();
        StartState(initialState);
    }
    
    public void StartState(State<Stove> initialState)
    {
        // initialize FSM
        stateMachine = new StateMachine<Stove>();
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
    }
}
