using Cards;
using UnityEngine;

namespace Abilities.Shoot
{
    [CreateAssetMenu(fileName = "ShootAbility", menuName = "Card/Ability/Shoot")]
    public class Shoot : AbilityCard
    {
        public float range;
        public float force;
        public float cost;
    }
}
