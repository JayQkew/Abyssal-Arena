using Multiplayer;
using Stats;
using UnityEngine;

namespace Slime
{
    public class SlimeStats : MonoBehaviour
    {
        [field:SerializeField] public PlayerStats Stats { get; private set; }
        [SerializeField] private Player player;

        public void SetStats(PlayerStats s, Player p)
        {
            Stats = s;
            player = p;
        }
    }
}
