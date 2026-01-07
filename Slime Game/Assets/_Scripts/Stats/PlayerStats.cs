using System.Collections.Generic;
using Cards;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Stats/Player")]
    public class PlayerStats : ScriptableObject
    {
        [field:SerializeField] public float Fuel { get; private set; }
        [field:SerializeField] public float MoveSpeed { get; private set; }
        [field:SerializeField] public MinMax Radius { get; private set; }
        [field:SerializeField] public MinMax Frequency { get; private set; }
        [field:SerializeField] public float DashCooldown { get; private set; }
        [field:SerializeField] public float DashForce { get; private set; }
        [field:SerializeField] public float DashCost { get; private set; }
        [field:SerializeField] public float InflateTime { get; private set; }

        public List<Card> cards = new();

        public void SetFuel(float v) => Fuel = v;
        public void SetMoveSpeed(float v) => MoveSpeed = v;
        public void SetRadius(MinMax v) => Radius = v;
        public void SetFrequency(MinMax v) => Frequency = v;
        public void SetDashCooldown(float v) => DashCooldown = v;
        public void SetDashForce(float v) => DashForce = v;
        public void SetDashCost(float v) => DashCost = v;
        public void SetInflateTime(float v) => InflateTime = v;
    }
}