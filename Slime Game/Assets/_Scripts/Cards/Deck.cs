using System.Collections.Generic;
using Stats;
using UnityEngine;

namespace Cards
{
    public class Deck : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        public Transform abilitiesParent;

        public void AddCard(Card card) => playerStats.cards.Add(card);
    }
}
