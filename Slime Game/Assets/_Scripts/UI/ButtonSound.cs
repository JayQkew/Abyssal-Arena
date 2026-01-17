using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public class ButtonSound : MonoBehaviour, ISelectHandler
    {
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void OnSelect(BaseEventData eventData)
        {
            audioSource.Play();
        }
    }
}
