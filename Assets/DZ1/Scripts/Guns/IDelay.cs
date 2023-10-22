using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDelay
{
    float Delay { get; set; }
    bool IsReseted { get; set; }

    void ResetDelay();
    IEnumerator CalculatingDelay(float deltaTime);
}
