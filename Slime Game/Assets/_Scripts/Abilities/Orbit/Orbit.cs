using Cards;
using UnityEngine;

namespace Abilities.Orbit
{
    [CreateAssetMenu(fileName = "OrbitAbility", menuName = "Card/Ability/Orbit")]
    public class Orbit : AbilityCard
    {
        public float speed;
        public float recoveryTime;
        public float hitForce;
    }
}
