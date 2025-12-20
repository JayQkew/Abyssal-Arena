using System;
using UnityEngine;

namespace Maps
{
    public class MatchHelper : MonoBehaviour
    {
        // also add all the references to the UI here
        
        [SerializeField] private Transform[] playerSpawns;
        [SerializeField] private Transform ballSpawn;

        private void Start()
        {
            // Spawns the player in their designated areas
        }
    }
}
