using AppStates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PodiumScreen : MonoBehaviour
{
    public void StartScreen() {
        AppState.Instance.SwitchState(AppStates.AppStates.MainMenu);
    }
}
