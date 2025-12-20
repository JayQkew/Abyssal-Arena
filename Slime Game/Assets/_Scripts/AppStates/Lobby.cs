using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppStates
{
    [Serializable]
    public class Lobby : State
    {
        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene("Lobby");
        }

        public override void Update()
        {
            // if both players ready -> go to game state
            bool[] playersReady = Multiplayer.Instance.ready;

            if (playersReady[0] && playersReady[1])
            {
                _manager.SwitchState(AppStates.Gameplay);
            }
        }

        public override void Exit()
        {
        }
    }
}