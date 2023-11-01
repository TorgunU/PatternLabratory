using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateMachine : IInputtableStateSwitcher
{
    void HandleInput();
    void Update();
}
