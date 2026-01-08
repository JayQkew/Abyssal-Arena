using System;
using AppStates.GameplayStates;
using Cards;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AppStates.SceneHandler
{
    public class DraftHandler : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Transform draftParent;

        private Draft _draft;

        private void Start()
        {
            _draft ??= AppState.Instance.gameplayState.draftState;

            Card[] draftedCards = _draft.DraftCards();

            for (int i = 0; i < draftedCards.Length; i++)
            {
                GameObject card = Instantiate(cardPrefab, draftParent);
                card.GetComponent<CardUI>().SetCardUI(draftedCards[i]);
                if (i == 0) EventSystem.current.firstSelectedGameObject = card;
            }
        }
    }
}