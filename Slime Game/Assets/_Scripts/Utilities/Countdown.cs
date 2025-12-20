using System;
using UnityEngine;

namespace Utilities
{
    [Serializable]
    public class Countdown : Timer
    {
        public Countdown(float maxTime, bool repeat = false) : base(maxTime, repeat)
        {
            Reset();
        }

        protected override void Tick(float deltaTime)
        {
            IsFinished = false;

            if (currTime > 0f)
            {
                currTime -= deltaTime;
                TotalTime += deltaTime;
                currTime = Mathf.Clamp(currTime, 0f, maxTime);
            }
            else
            {
                IsFinished = true;
                if (repeat) Reset();
            }
        }

        public sealed override void Reset()
        {
            currTime = maxTime;
            IsFinished = false;
        }
        
        public float RemainingTime => currTime;
    }
}