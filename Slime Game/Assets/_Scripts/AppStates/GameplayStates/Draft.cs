using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace AppStates.GameplayStates
{
    [Serializable]
    public class Draft : GameplayState
    {
        public Deck lostPlayerDeck;
        
        public int draftSize;
        public List<Card> cards = new();

        public override void Enter(Gameplay m)
        {
            base.Enter(m);

            SceneManager.LoadScene("Draft");
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }

        public Card[] DraftCards()
        {
            List<Card> availableCards = cards.ToList();
            Card[] selectedCards = new Card[draftSize];
            for (int i = 0; i < draftSize; i++)
            {
                int randomIndex = Random.Range(0, availableCards.Count);
                Card card = availableCards[randomIndex];
                availableCards.RemoveAt(randomIndex);
                selectedCards[i] = card;
            }
            return selectedCards;
        }
    }
}