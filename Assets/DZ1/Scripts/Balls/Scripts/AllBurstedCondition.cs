using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Patterns.DZ1.Balls
{
    public class AllBurstedCondition : VictoryCondition
    {
        public AllBurstedCondition(List<Ball> balls) : base(balls)
        { }

        protected override void CheckCondition()
        {
            if (_balls.Any(ball => ball.IsBursted == false))
            {
                return;
            }

            Completed.Invoke();
        }

        public override event Action Completed;
    }
}