using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Child : MonoBehaviour
{
    public Food food;
    public float money;
    public StateMachine<Child> stateMachine = new StateMachine<Child>();
    public Text currentState;
    
    public float entryTime = 0.5f, time = 3, exitTime = 0.5f;
    public int priority = 2;
    
    public void StartState(State<Child> initialState)
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

    public void BuyFood(){
        GameObject foodObject = new GameObject("Food");
        Food food = foodObject.AddComponent<Food>();
        if(this.money < food.price){
            Destroy(foodObject);
            return;
        }
        this.money -= food.price;
        this.food = food;
    }
}
