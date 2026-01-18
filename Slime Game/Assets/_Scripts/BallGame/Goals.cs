using System;
using AppStates;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallGame
{
    public class Goals : MonoBehaviour
    {
        public int scoringTeam;
        private AudioSource _audioSource;

        public bool canScore = true;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ball") && canScore) {
                _audioSource.Play();
                AppState.Instance.gameplayState.matchState.PlayerPoint(scoringTeam);
            }
        }
    }
}