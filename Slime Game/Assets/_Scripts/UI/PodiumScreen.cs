using AppStates;
using UnityEngine;

public class PodiumScreen : MonoBehaviour
{
    public void StartScreen() {
        AppState.Instance.SwitchState(AppStates.AppStates.MainMenu);
    }
}
