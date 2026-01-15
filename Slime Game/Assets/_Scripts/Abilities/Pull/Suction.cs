using Cards;
using UnityEngine;

namespace Abilities.Pull
{
    [CreateAssetMenu(fileName = "SuctionAbility", menuName = "Card/Ability/Suction")]
    public class Suction : AbilityCard
    {
        public float radius;
        public float force;
    }
}
