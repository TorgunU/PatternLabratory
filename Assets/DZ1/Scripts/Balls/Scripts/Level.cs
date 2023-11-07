using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ1.Balls
{
    public class Level : MonoBehaviour
    {
        private VictoryCondition _victoryCondition;

        public void Init(VictoryCondition victoryCondition)
        {
            _victoryCondition = victoryCondition;
            _victoryCondition.Completed += OnVictoryConditionCompleted;
        }

        public void SetVictoryStratagy(VictoryCondition victoryCondition)
        {
            _victoryCondition = victoryCondition;
            _victoryCondition.Completed += OnVictoryConditionCompleted;
        }

        private void OnVictoryConditionCompleted()
        {
            Debug.Log("Victory!");
        }
    }
}