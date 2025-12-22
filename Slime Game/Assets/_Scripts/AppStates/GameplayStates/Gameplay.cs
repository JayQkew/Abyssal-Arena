using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppStates.GameplayStates
{
    [Serializable]
    public class Gameplay : State
    {
        public int[] points = new int[2];
        
        private GameplayState _currState;
        public GameplayStates currState;
        public Match matchState = new();
        public Draft draftState = new();

        private Dictionary<GameplayStates, GameplayState> _states = new();

        public override void Enter()
        {
            base.Enter();

            _states = new Dictionary<GameplayStates, GameplayState>
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
            points[0] = 0;
            points[1] = 0;
        }

        public void SwitchState(GameplayStates state)
        {
            currState = state;
            
            _currState.Exit();
            _currState = _states[currState];
            _currState.Enter(this);
        }

        public void PlayerPoint(int playerIndex)
        {
            points[playerIndex]++;
            
            if (GameConditionMet(playerIndex))
            {
                manager.SwitchState(AppStates.Podium); //with player that won
            }
            else
            {
                draftState.lostPlayerDeck = Multiplayer.Instance.players[1 - playerIndex].transform
                    .GetComponentInChildren<Deck>();
                SwitchState(GameplayStates.Draft); //with player that lost
            }
        }

        public bool GameConditionMet(int playerIndex)
        {
            int currScore = points[playerIndex];
            int otherScore = points[1 - playerIndex];
            
            bool gamePoint = currScore >= 4;
            bool leadByTwo = (currScore - otherScore) >= 2;
            
            return gamePoint && leadByTwo;
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