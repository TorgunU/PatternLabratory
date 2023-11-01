using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputtableState : IState
{
    void Update();
    void HandleInput();
}
