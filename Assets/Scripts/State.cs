using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    public float time;

    // validate if state is ready
    public abstract bool IsValid(T entity);

    // action to execute when enter the state
    public abstract void Enter(T entity, Mom mom);

    // is call by update miner function
    public abstract void Execute(T entity);

    // execute when exit from state
    public abstract void Exit(T entity, Mom mom);
}
