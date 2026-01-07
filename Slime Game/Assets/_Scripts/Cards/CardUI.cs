using System;
using System.Collections;
using AppStates;
using AppStates.GameplayStates;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cards
{
    public class CardUI : MonoBehaviour, ISubmitHandler, ISelectHandler
    {
        [SerializeField] private Card card;

        [SerializeField] private Animator anim;
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Image icon;
        
        private WaitForSeconds _submitWait = new WaitForSeconds(1f);
        
        private Draft _draft;
        private void Start()
        {
            _draft = AppState.Instance.gameplayState.draftState;
        }

        public void SetCardUI(Card c)
        {
            card = c;
            header.SetText(c.name);
            description.SetText(c.description);
            icon.sprite = c.icon;
        }

        public void OnSelect(BaseEventData eventData)
        {
        }

        public void OnSubmit(BaseEventData eventData)
        {
            _draft.lostPlayerDeck.AddCard(card);
        }

        private IEnumerator Choose()
        {
            yield return _submitWait;
            AppState.Instance.gameplayState.SwitchState(GameplayStates.Match);
        }
    }
}
