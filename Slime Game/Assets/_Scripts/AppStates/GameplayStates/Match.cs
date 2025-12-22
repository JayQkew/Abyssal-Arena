using System;
using Maps;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace AppStates.GameplayStates
{
    [Serializable]
    public class Match : GameplayState
    {
        public int[] points;
        [SerializeField] private int winPoints;
        public Countdown countdown; // till sudden death
        public Countdown suddenDeath;
        private MapManager _mapManager;

        [HideInInspector] public UnityEvent onSuddenDeath;

        public override void Enter(Gameplay m)
        {
            base.Enter(m);

            _mapManager ??= new MapManager();
            _mapManager.LoadMap();
            
            countdown.SetMaxTime(countdown.maxTime);
            suddenDeath.SetMaxTime(suddenDeath.maxTime);
        }

        public override void Update()
        {
            if (countdown.IsFinished)
            {
                suddenDeath.Update();

                if (suddenDeath.IsFinished)
                {
                    if (points[0] == points[1]) manager.SwitchState(GameplayStates.Match);
                    else manager.PlayerPoint(CheckWinner());
                }
            }
            else
            {
                countdown.Update();

                if (countdown.IsFinished) onSuddenDeath.Invoke();
            }
            
            PointTesting();
        }

        public override void Exit()
        {
        }

        private void PointTesting()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Alpha1)) PlayerPoint(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) PlayerPoint(1);
#endif
        }

        public void PlayerPoint(int playerIndex)
        {
            points[playerIndex]++;
            if (MatchConditionMet(playerIndex))
            {
                manager.PlayerPoint(playerIndex);
            }
        }

        private int CheckWinner()
        {
            return points[0] > points[1] ? 0 : 1;
        }

        public bool MatchConditionMet(int playerIndex)
        {
            return points[playerIndex] >= winPoints;
        }
    }
}