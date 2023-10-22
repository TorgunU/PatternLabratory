using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTradeStratagy : ITradeStratagy
{
    public void ShowGoods()
    {
        Debug.Log("“орговец отказалс€ показывать вам эти товары...");
    }
}
