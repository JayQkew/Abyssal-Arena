using Multiplayer;
using TMPro;
using UnityEngine;
using Utilities;

namespace AppStates.SceneHandler
{
    public class LobbyHandler : MonoBehaviour
    {
        public Countdown countdown;

        [SerializeField] private TextMeshProUGUI timeTxt;
        [SerializeField] private GameObject[] readyTxt;

        private string _startTxt;
        private int _lastSecondShown = -1;

        private void Start()
        {
            readyTxt[0].SetActive(false);
            readyTxt[1].SetActive(false);

            _startTxt = timeTxt.text;
            countdown.Reset();
        }

        private void Update()
        {
            bool[] playersReady =
            {
                MultiplayerManager.Instance.players[0].ready,
                MultiplayerManager.Instance.players[1].ready,
            };

            readyTxt[0].SetActive(playersReady[0]);
            readyTxt[1].SetActive(playersReady[1]);

            if (playersReady[0] && playersReady[1])
            {
                countdown.Update();
                UpdateCountdownText();

                if (countdown.IsFinished)
                {
                    AppState.Instance.SwitchState(AppStates.Gameplay);
                }
            }
            else
            {
                ResetCountdownUI();
            }
        }

        private void UpdateCountdownText()
        {
            float time = countdown.RemainingTime;
            int seconds = Mathf.CeilToInt(time);

            if (seconds == _lastSecondShown)
                return;

            _lastSecondShown = seconds;

            timeTxt.text = seconds <= 0 ? "GO!" : seconds.ToString();
        }

        private void ResetCountdownUI()
        {
            countdown.Reset();
            _lastSecondShown = -1;
            timeTxt.text = _startTxt;
        }
    }
}