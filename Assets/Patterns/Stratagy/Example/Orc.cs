using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class Orc : Enity
    {
        protected override void Affect(IEnumerable<Enity> enities)
        {
            Debug.Log($"Найдено {enities.Count()} сущностей");
        }
    }
}