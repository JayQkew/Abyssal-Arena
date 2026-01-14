using System;
using AppStates.GameplayStates;
using Cards;
using Multiplayer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

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
            
            InputSystemUIInputModule inputModule = EventSystem.current.GetComponent<InputSystemUIInputModule>();
            
            MultiplayerManager.Instance.SetUIInteraction(_draft.lostPlayerIndex, true, inputModule);
            MultiplayerManager.Instance.SetUIInteraction(1 - _draft.lostPlayerIndex, false, inputModule);


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