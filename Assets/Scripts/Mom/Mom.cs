using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mom : MonoBehaviour
{
    public List<OccupiedState> activities;
    public StateMachine<Mom> stateMachine;
    public List<Text> stateTexts = new List<Text>();
    public Text currentState;

    // Start is called before the first frame update
    void Start()
    {
        StartStateMachine();
        activities = new List<OccupiedState>();
        AddChildActivity();
        AddStoveActivity();
        AddWashingActivity();
    }

    public void StartStateMachine()
    {
        // initialize FSM
        stateMachine = new StateMachine<Mom>();
        stateMachine.entity = this;
    }

    public void AddActivity(OccupiedState activity){
        activities.Add(activity);
        activities.Sort((a, b) => {
            return a.priority.CompareTo(b.priority);
        });
    }

    public void AddChildActivity(){
        AddActivity(new OccupiedState(0.5f, 2, 0, stateTexts, "Commissioning child"));
    }
    public void AddStoveActivity(){
        AddActivity(new OccupiedState(1, 0, 1, stateTexts, "Setting stove"));
    }
    public void AddWashingActivity(){
        AddActivity(new OccupiedState(1, 1, 2, stateTexts, "Loading washer"));
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
        if(stateMachine.CurrentState == null && activities.Count > 0){
            stateMachine.Begin(activities[0]);
            activities.RemoveAt(0);
        }
    }
    
}
