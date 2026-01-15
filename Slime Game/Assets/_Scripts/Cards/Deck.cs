using System;
using System.Collections.Generic;
using Slime;
using Stats;
using UnityEngine;

namespace Cards
{
    public class Deck : MonoBehaviour
    {
        private PlayerStats _playerStats;
        public Transform abilitiesParent;

        private void Start()
        {
            _playerStats = GetComponent<SlimeStats>().Stats;
        }

        public void AddCard(Card card)
        {
            _playerStats.cards.Add(card);
            card.Apply(this);
        }
    }
}
