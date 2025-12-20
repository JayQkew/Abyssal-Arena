using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppStates.GameplayStates
{
    [Serializable]
    public class Gameplay : State
    {
        public GameplayStates currState;
        private GameplayState _currState;

        public Match matchState = new();
        public Draft draftState = new();

        private Dictionary<GameplayStates, GameplayState> _states = new();

        public override void Enter()
        {
            base.Enter();

            _states = new Dictionary<GameplayStates, GameplayState>()
            {
                { GameplayStates.Match, matchState },
                { GameplayStates.Draft, draftState },
            };
            
            _currState = _states[currState];
            _currState.Enter(this);
            Debug.Log("Entering Gameplay");
        }

        public override void Update()
        {
            _currState.Update();
        }

        public override void Exit()
        {
        }

        public void SwitchState(GameplayStates state)
        {
            currState = state;
            
            _currState.Exit();
            _currState = _states[currState];
            _currState.Enter(this);
        }
    }

    public abstract class GameplayState
    {
        protected Gameplay manager;
        public virtual void Enter(Gameplay m)
        {
            manager ??= m;
        }
        public abstract void Update();
        public abstract void Exit();
    }

    public enum GameplayStates
    {
        Match,
        Draft
    }
}