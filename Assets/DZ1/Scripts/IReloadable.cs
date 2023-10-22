using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadable
{
    Magazine Magazine { get; set; }

    void Reload();
}
