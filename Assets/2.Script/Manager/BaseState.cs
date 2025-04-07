using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public enum state { move, jump, attack, dead}
    protected state currentState;

    protected virtual void Start()
    {
        currentState = state.move;
    }

    protected virtual void Update()
    {
        StateMachine();
    }

    public void ChangeState(state nowState)
    {
        currentState = nowState;
    }

    protected abstract void StateMachine();
}
