using System;
using System.Collections.Generic;
using Cards;
using Multiplayer;
using UnityEngine;
using UnityEngine.Events;

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

        public UnityEvent<int[]> onScore;

        public override void Enter()
        {
            base.Enter();
            
            points[0] = 0;
            points[1] = 0;

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
            onScore.Invoke(points);
            if (GameConditionMet(playerIndex))
            {
                manager.podiumState.winner = playerIndex;
                manager.SwitchState(AppStates.Podium); //with player that won
            }
            else
            {
                draftState.lostPlayerDeck = MultiplayerManager.Instance.players[1 - playerIndex].player
                    .GetComponentInChildren<Deck>();
                draftState.lostPlayerIndex = 1 - playerIndex;
                SwitchState(GameplayStates.Draft); //with player that lost
            }
        }

        public bool GameConditionMet(int playerIndex)
        {
            return points[playerIndex] == 3;
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