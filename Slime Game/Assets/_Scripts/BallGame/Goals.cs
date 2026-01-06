using AppStates;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallGame
{
    public class Goals : MonoBehaviour
    {
        public int scoringTeam;

        public bool canScore = true;
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ball") && canScore) {
                AppState.Instance.gameplayState.matchState.PlayerPoint(scoringTeam);
            }
        }
    }
}