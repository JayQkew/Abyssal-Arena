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

        }

        public override void Exit()
        {
        }
    }
}