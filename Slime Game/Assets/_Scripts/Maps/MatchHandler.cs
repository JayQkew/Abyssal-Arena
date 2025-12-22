using System;
using UnityEngine;

namespace Maps
{
    public class MatchHandler : MonoBehaviour
    {
        // also add all the references to the UI here

        [SerializeField] private Transform[] playerSpawns;

        private void Start()
        {
            // Spawns the player in their designated areas
            for (int i = 0; i < playerSpawns.Length; i++)
            {
                Multiplayer.Instance.players[i].transform.position = playerSpawns[i].position;
            }
        }
    }
}