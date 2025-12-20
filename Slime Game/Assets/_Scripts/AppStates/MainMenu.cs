using System;
using UnityEngine.SceneManagement;

namespace AppStates
{
    [Serializable]
    public class MainMenu : State
    {
        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene("MainMenu");
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}
