using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

namespace Multiplayer
{
    public class MultiplayerManager : MonoBehaviour
    {
        public static MultiplayerManager Instance { get; private set; }
        private PlayerInputManager _playerInputManager;
        public Player[] players = new Player[2];
        [SerializeField] private Transform[] spawnPoints;

        private MultiplayerCollider _multiplayerCollider;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(this);
            }

            _playerInputManager = GetComponent<PlayerInputManager>();
            _multiplayerCollider = GetComponent<MultiplayerCollider>();
        }

        public void OnPlayerJoined(PlayerInput playerInput)
        {
            Player player = players[_playerInputManager.playerCount - 1];
            int playerIndex = _playerInputManager.playerCount - 1;
            player.SetPlayer(playerInput, playerIndex, transform, spawnPoints[playerIndex]);
            _multiplayerCollider.OnPlayerJoined(playerInput);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Draft" && scene.name != "StartScreen" && scene.name != "MapSelect" && scene.name != "Podium")
            {
                spawnPoints = new Transform[2];
                Transform playerSpawnPoints = GameObject.FindGameObjectWithTag("PlayerSpawns").transform;
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i] = playerSpawnPoints.GetChild(i);
                }
            }
        }

        public void SetUIInteraction(int playerIndex, bool active, InputSystemUIInputModule uiInputModule)
        {
            PlayerInput playerInput = players[playerIndex].input;
            Debug.Log(playerInput + " " + (active ? "active" : "inactive"));
            players[playerIndex].input.uiInputModule = active ? uiInputModule : null;
        }
    }
}