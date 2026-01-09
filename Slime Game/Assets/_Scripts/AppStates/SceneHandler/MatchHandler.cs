using UnityEngine;

namespace AppStates.SceneHandler
{
    public class MatchHandler : MonoBehaviour
    {
        // also add all the references to the UI here

        [SerializeField] private Transform[] playerSpawns;

        private void Start()
        {
            // Spawns the player in their designated areas
            GameObject[] players = Multiplayer.Instance.players;
            for (int i = 0; i < playerSpawns.Length; i++)
            {
                SoftBody softBody = players[i].GetComponentInChildren<SoftBody>();
                softBody.MoveSoftBody(playerSpawns[i].position);
                softBody.ResetVelocity();
            }
        }
    }
}