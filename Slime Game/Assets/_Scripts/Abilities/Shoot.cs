using Cards;
using UnityEngine;

namespace Abilities
{
    public class Shoot : AbilityCard
    {
        public GameObject bulletPrefab;
        public float force;
        public float size;

        public override void Apply(Deck deck)
        {
            base.Apply(deck);
        }
    }
}
