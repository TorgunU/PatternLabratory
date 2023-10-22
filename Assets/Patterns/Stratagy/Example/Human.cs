using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Patterns.Stratagy.Example
{
    public class Human : Enity
    {
        protected override void Affect(IEnumerable<Enity> enities)
        {
            foreach (var enity in enities)
            {
                if (enity is Orc)
                {
                    Debug.Log($"Найдено {enities.Count()} орков");
                }
            }
        }
    }
}