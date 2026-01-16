using System;
using UnityEngine;
using Utilities;

namespace Props
{
    public class Spawner : MonoBehaviour
    {
        public SpawnObject spawn;
        public Timer respawnTimer;
        [SerializeField] private float spawnForce;

        private void Start()
        {
            spawn.rb.AddForceY(spawnForce, ForceMode2D.Impulse);
        }

        private void Update()
        {
            if (!spawn.active)
            {
                respawnTimer.Update();
                if (respawnTimer.IsFinished)
                {
                    spawn.Respawn(transform.position);
                    spawn.rb.AddForceY(spawnForce, ForceMode2D.Impulse);
                    respawnTimer.Reset();
                }
            }
        }
    }
}