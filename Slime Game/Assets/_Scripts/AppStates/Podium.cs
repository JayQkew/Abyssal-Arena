using System;
using Multiplayer;
using UnityEngine.SceneManagement;

namespace AppStates
{
    [Serializable]
    public class Podium : State
    {
        public int winner;
        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene("Podium");
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            manager.DestroySelf();
            MultiplayerManager.Instance.DestroySelf();
        }
    }
}
