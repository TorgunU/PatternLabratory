using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementState : IInputtableState
{
    protected readonly IInputtableStateSwitcher StateSwitcher;
    protected readonly PlayerMovementStateMachineData MachineData;

    private readonly PlayerMovement _movement;

    public PlayerMovementState(IInputtableStateSwitcher stateSwitcher, PlayerMovement movement, 
        PlayerMovementStateMachineData machineData)
    {
        StateSwitcher = stateSwitcher;
        _movement = movement;
        MachineData = machineData;
    }

    protected PlayerMovement PlayerMovement => _movement;
    protected IMovementEvents MovementEvents => _movement.MovementEvents;

    public virtual void Enter()
    {
        Debug.Log(GetType());
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {

    }

    public abstract void Update();

    protected abstract void AddInputActionsCallbacks();
    protected abstract void RemoveInputActionsCallbacks();
}
