using System;
using System.Collections.Generic;
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
        public List<Card> cards;
        [SerializeField] private AllCards allCards;

        private bool _firstTime = true;

        public override void Enter(Gameplay m)
        {
            base.Enter(m);

            SceneManager.LoadScene("Draft");

            if (_firstTime)
            {
                cards = new List<Card>();
                cards.AddRange(allCards.cards);
                _firstTime = false;
            }
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }

        public Card[] DraftCards()
        {
            Card[] selectedCards = new Card[draftSize];
            for (int i = 0; i < draftSize; i++)
            {
                Card card = cards[Random.Range(0, cards.Count)];
                selectedCards[i] = card;
            }
            return selectedCards;
        }
    }
}