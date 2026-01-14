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

        public UnityEvent<string[]> onScore;

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
            onScore.Invoke(PointsToString());
            if (GameConditionMet(playerIndex))
            {
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
            int currScore = points[playerIndex];
            int otherScore = points[1 - playerIndex];

            bool gamePoint = currScore >= 4;
            bool leadByTwo = (currScore - otherScore) >= 2;

            return gamePoint && leadByTwo;
        }

        public string[] PointsToString()
        {
            string[] p = new string[points.Length];

            // 1. Check for Deuce or Advantage (Both players have at least 3 points / "40")
            if (points[0] >= 3 && points[1] >= 3)
            {
                if (points[0] == points[1])
                {
                    p[0] = "40"; // Or "Deuce"
                    p[1] = "40"; // Or "Deuce"
                }
                else if (points[0] > points[1])
                {
                    p[0] = "A";
                    p[1] = ""; // Or empty string "" if you prefer
                }
                else
                {
                    p[0] = "";
                    p[1] = "A";
                }
            }
            // 2. Standard Scoring (No one has hit Deuce/Advantage territory yet)
            else
            {
                for (int i = 0; i < points.Length; i++)
                {
                    // If the game is already won (e.g. 4 vs 1), this handles the winner's formatting
                    // though your GameConditionMet usually catches this before UI updates.
                    if (points[i] >= 4)
                    {
                        p[i] = "W";
                    }
                    else
                    {
                        switch (points[i])
                        {
                            case 0:
                                p[i] = "00";
                                break;
                            case 1:
                                p[i] = "15";
                                break;
                            case 2:
                                p[i] = "30";
                                break;
                            case 3:
                                p[i] = "40";
                                break;
                        }
                    }
                }
            }

            return p;
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