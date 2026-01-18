using System;
using TMPro;
using UnityEngine;

namespace AppStates.SceneHandler
{
    public class PodiumHandler : MonoBehaviour
    {
        public TextMeshProUGUI winnerTxt;

        private void Start()
        {
            int winner = AppState.Instance.podiumState.winner;
            winnerTxt.SetText($"player {winner + 1} wins");
        }
    }
}
