using Cards;
using UnityEngine;

namespace Abilities.Push
{
    [CreateAssetMenu(fileName = "RepulsionAbility", menuName = "Card/Ability/Repulsion")]
    public class Repulsion : AbilityCard
    {
        public float radius;
        public float force;
    }
}
