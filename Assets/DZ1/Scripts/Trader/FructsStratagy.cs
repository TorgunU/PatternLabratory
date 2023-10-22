using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FructsStratagy : ITradeStratagy
{
    public void ShowGoods()
    {
        Debug.Log("Торговец показал еще свежие фрукты...");
    }
}
