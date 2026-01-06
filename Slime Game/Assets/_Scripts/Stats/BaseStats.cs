using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Stats System/Player Stats")]
    public class BaseStats : ScriptableObject
    {
        public float fuel;
        public float moveSpeed;
        public MinMax radius;
        public MinMax frequency;
        public float dashCooldown;
        public float dashForce;
        public float dashCost;
        public float inflateTime;
    }
}
