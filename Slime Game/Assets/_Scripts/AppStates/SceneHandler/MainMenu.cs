using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppStates.SceneHandler
{
    public class MainMenu : MonoBehaviour
    {
        public void ToLobby() => AppState.Instance.SwitchState(AppStates.Lobby);

        public void ExitGame() => Application.Quit();

        public void GoToHowToPlay() => SceneManager.LoadScene("HowToPlay");
    }
}