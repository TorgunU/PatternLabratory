using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class PlayerMovementStateMachine : IPlayerStateMachine
{
    private List<IInputtableState> _states;
    private IInputtableState _currentState;

    public PlayerMovementStateMachine()
    {
        
    }

    public void Switch(IInputtableState newState)
    {
        IInputtableState inputtableState = _states.Find(state => state == newState);
        _currentState.Exit();
        _currentState = inputtableState;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
