using System;
using System.Collections.Generic;
using Stats;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    public List<Card> cards;
    public Transform abilitiesParent;

    /// <summary>
    /// when the player selects a card
    /// </summary>
    /// <param name="card">the card added</param>
    public void AddCard(Card card) {

        foreach (GameObject ability in card.abilities) {
            Instantiate(ability, Vector3.zero, Quaternion.identity, abilitiesParent);
        }
        cards.Add(card);
    }

    public void ClearDeck() {
        cards.Clear();
        Destroy(abilitiesParent);
        abilitiesParent = new GameObject("Abilities").transform;
    }
}
