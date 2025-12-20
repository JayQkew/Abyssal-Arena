using System;
using UnityEngine;

namespace Utilities
{
    [Serializable]
    public class Timer
    {
        public float maxTime;
        public float currTime;
        [SerializeField] protected bool repeat;
        public float TotalTime { get; protected set; }
        public bool IsFinished { get; protected set; }

        public Timer(float maxTime, bool repeat = false)
        {
            this.maxTime = maxTime;
            this.repeat = repeat;
            Reset();
            TotalTime = 0f;
        }

        public virtual void Update()
        {
            Tick(Time.deltaTime);
        }

        protected virtual void Tick(float deltaTime)
        {
            IsFinished = false;
            if (currTime < maxTime)
            {
                currTime += Time.deltaTime;
                TotalTime += Time.deltaTime;
                currTime = Mathf.Clamp(currTime, 0, maxTime);
            }
            else if (currTime >= maxTime)
            {
                IsFinished = true;
                if (repeat) Reset();
            }
        }

        public virtual void Reset()
        { 
            currTime = 0f;
            IsFinished = false;
        }

        public float Progress => maxTime > 0 ? currTime / maxTime : 0f;
        
        public void SetMaxTime(float newMaxTime, bool resetTimer = true)
        {
            maxTime = newMaxTime;
            if (resetTimer) Reset();
        }
    }
}