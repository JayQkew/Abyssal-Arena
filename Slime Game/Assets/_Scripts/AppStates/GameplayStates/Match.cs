using System;
using Maps;
using UnityEngine;
using Utilities;

namespace AppStates.GameplayStates
{
    [Serializable]
    public class Match : GameplayState
    {
        public int[] points;
        public Countdown countdown; // till sudden death
        public Countdown suddenDeath;
        private MapManager _mapManager;
        public override void Enter(Gameplay m)
        {
            base.Enter(m);
            
            _mapManager ??= new MapManager();
            _mapManager.LoadMap();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
