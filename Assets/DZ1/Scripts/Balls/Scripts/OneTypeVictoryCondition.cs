using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assets.Patterns.DZ1.Balls
{
    public class OneTypeVictoryCondition : VictoryCondition
    {
        private BallType _ballType;

        public OneTypeVictoryCondition(List<Ball> balls, BallType ballType) : base(balls)
        {
            _ballType = ballType;
        }

        protected override void CheckCondition()
        {
            if(_balls.FindAll(ball => ball.BallType == _ballType)
                .Any(ball => ball.IsBursted == false))
            {
                return;
            }
            Completed.Invoke();
        }

        public override event Action Completed;
    }
}