using UnityEngine;

namespace Stats
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private BaseStats baseStats;

        public float fuel;
        public float moveSpeed;
        public MinMax radius;
        public MinMax frequency;
        public float dashCooldown;
        public float dashForce;
        public float dashCost;
        public float inflateTime;
    
        private void Awake() {
            fuel = baseStats.fuel;
            moveSpeed = baseStats.moveSpeed;
            radius = baseStats.radius;
            frequency = baseStats.frequency;
            dashCooldown = baseStats.dashCooldown;
            dashForce = baseStats.dashForce;
            dashCost = baseStats.dashCost;
            inflateTime = baseStats.inflateTime;
        }
    }
}