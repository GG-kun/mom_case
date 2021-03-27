using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mom : MonoBehaviour
{
    public List<OccupiedState> activities;
    public StateMachine<Mom> stateMachine;
    public Text currentState;

    public Child child;
    public Stove stove;
    public Washer washer;

    public float money = 50f;
    public Food food;

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
            return b.priority.CompareTo(a.priority);
        });
    }

    public void AddChildActivity(){
        AddActivity(new OccupiedState(child.entryTime, child.priority, 0, "Commissioning child"));
    }
    public void AddStoveActivity(){
        AddActivity(new OccupiedState(stove.entryTime, stove.priority, 1, "Setting stove"));
    }
    public void AddWashingActivity(){
        AddActivity(new OccupiedState(washer.entryTime*washer.load, washer.priority, 2, "Loading washer"));
    }

    public OccupiedState PopActivity(){
        int index = activities.Count-1;
        OccupiedState activity = activities[index];
        activities.RemoveAt(index);
        return activity;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
        NextActivity();
    }

    public void NextActivity() {        
        if(stateMachine.CurrentState == null && activities.Count > 0){
            OccupiedState nextActivity = PopActivity();
            if(!stateMachine.Begin(nextActivity)){
                NextActivity();
                activities.Add(nextActivity);
            }            
        }
    }
    
}
