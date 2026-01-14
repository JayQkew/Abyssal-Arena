using System;
using Cards;
using Slime;
using Stats;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace Multiplayer
{
    [Serializable]
    public class Player
    {
        public PlayerInput input;
        public GameObject player;
        public bool ready;

        [SerializeField] private string layer;
        [SerializeField] private Material material;
        [SerializeField] private GameObject face;

        public void SetPlayer(PlayerInput playerInput, int num, Transform parent, Transform spawnPos, PlayerStats stats)
        {
            input = playerInput;
            player = playerInput.gameObject;
            SetSoftBody(playerInput);

            player.name = $"Player {num}";
            playerInput.transform.SetParent(parent);
            playerInput.transform.position = spawnPos.position;
            Object.Instantiate(face, playerInput.gameObject.transform.GetChild(0).transform, false);

            playerInput.actions["Ready"].performed += ctx => ready = !ready;
            
            player.transform.GetChild(0).GetComponent<SlimeStats>().SetStats(stats, this);
        }

        private void SetSoftBody(PlayerInput playerInput)
        {
            GameObject softBody = playerInput.transform.GetChild(0).gameObject;
            softBody.layer = LayerMask.NameToLayer(layer);
            softBody.GetComponent<SoftBody>().meshMaterial = material;
        }
    }
}