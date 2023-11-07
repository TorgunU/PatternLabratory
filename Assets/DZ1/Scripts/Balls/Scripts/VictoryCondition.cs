using System;
using System.Collections.Generic;

namespace Assets.Patterns.DZ1.Balls
{
    public abstract class VictoryCondition
    {
        protected List<Ball> _balls;

        public VictoryCondition(List<Ball> balls)
        {
            _balls = balls;
            SubscribeOnBallEvent();
        }

        public void SubscribeOnBallEvent()
        {
            _balls.ForEach(ball => { ball.Bursted += OnBallBursted; });
        }

        protected virtual void OnBallBursted(Ball ball)
        {
            ball.Bursted -= OnBallBursted;
            CheckCondition();
        }

        protected abstract void CheckCondition();

        public abstract event Action Completed;
    }
}