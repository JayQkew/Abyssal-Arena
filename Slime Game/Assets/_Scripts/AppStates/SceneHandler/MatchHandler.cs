using System;
using Multiplayer;
using UnityEngine;

namespace AppStates.SceneHandler
{
    public class MatchHandler : MonoBehaviour
    {
        [SerializeField] private Transform[] playerSpawns;
        [SerializeField] private GameObject suddenDeathScreen;

        private void Start()
        {
            // Spawns the player in their designated areas
            for (int i = 0; i < playerSpawns.Length; i++)
            {
                GameObject player = MultiplayerManager.Instance.players[i].player;
                SoftBody softBody = player.GetComponentInChildren<SoftBody>();
                softBody.MoveSoftBody(playerSpawns[i].position);
                softBody.ResetVelocity();
            }
            
            AppState.Instance.gameplayState.matchState.onSuddenDeath.AddListener(ActivateSuddenDeathScreen);
        }

        private void OnDisable()
        {
            AppState.Instance.gameplayState.matchState.onSuddenDeath.RemoveListener(ActivateSuddenDeathScreen);
        }

        private void ActivateSuddenDeathScreen() => suddenDeathScreen.SetActive(true);
    }
}