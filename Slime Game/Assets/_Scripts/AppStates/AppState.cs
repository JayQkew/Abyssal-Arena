using System.Collections.Generic;
using AppStates.GameplayStates;
using UnityEngine;

namespace AppStates
{
    public class AppState : MonoBehaviour
    {
        public static AppState Instance { get; private set; }

        public AppStates currState;
        private State _currState;

        public MainMenu menuState = new();
        public Lobby lobbyState = new();
        public Gameplay gameplayState = new();
        public Podium podiumState = new();

        private Dictionary<AppStates, State> _states = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _states = new Dictionary<AppStates, State>
            {
                { AppStates.MainMenu, menuState },
                { AppStates.Lobby, lobbyState },
                { AppStates.Gameplay, gameplayState },
                { AppStates.Podium, podiumState }
            };
        }

        private void Start()
        {
            _currState = _states[currState];
            _currState.Enter();
        }

        private void Update()
        {
            _currState.Update();
        }

        public void SwitchState(AppStates nextState)
        {
            currState = nextState;

            _currState.Exit();
            _currState = _states[nextState];
            _currState.Enter();
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }

    public abstract class State
    {
        protected AppState manager;

        public virtual void Enter()
        {
            manager ??= AppState.Instance;
        }

        public abstract void Update();

        public abstract void Exit();
    }

    public enum AppStates
    {
        MainMenu,
        Lobby,
        Gameplay,
        Podium,
    }
}