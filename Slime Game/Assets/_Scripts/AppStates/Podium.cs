using System;
using UnityEngine.SceneManagement;

namespace AppStates
{
    [Serializable]
    public class Podium : State
    {
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
        }
    }
}
