using System;
using System.Globalization;
using AppStates;
using AppStates.GameplayStates;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI[] gamePoints = new TextMeshProUGUI[2];
        [SerializeField] private TextMeshProUGUI[] setPoints = new TextMeshProUGUI[2];
        [SerializeField] private TextMeshProUGUI time;
        public Color suddenDeathText;

        private Gameplay _gameplayState;
        private int _lastDisplayedTime = -1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetPoint(_gameplayState.PointsToString());
        }

        private void OnEnable()
        {
            _gameplayState ??= AppState.Instance.gameplayState;
            if (_gameplayState == null)
            {
                Debug.LogError("No gameplay state found");
                return;
            }

            _gameplayState.matchState.onScore.AddListener(GamePoint);
        }

        private void OnDisable()
        {
            if (_gameplayState == null)
            {
                Debug.LogError("No gameplay state found");
                return;
            }

            _gameplayState.matchState.onScore.RemoveListener(GamePoint);
        }

        private void LateUpdate()
        {
            Match match = _gameplayState.matchState;

            float currentTime = match.countdown.IsFinished ? match.suddenDeath.currTime : match.countdown.currTime;

            int timeToDisplay = Mathf.FloorToInt(currentTime + 1);
            
            if (match.countdown.IsFinished)
            {
                time.color = suddenDeathText;
            }

            if (timeToDisplay == Mathf.FloorToInt(_lastDisplayedTime)) return;
            _lastDisplayedTime = timeToDisplay;
            time.SetText(timeToDisplay.ToString());
        }

        private void GamePoint(int[] points)
        {
            for (int i = 0; i < gamePoints.Length; i++)
            {
                gamePoints[i].SetText(points[i].ToString());
            }
        }

        private void SetPoint(string[] points)
        {
            setPoints[0].SetText(points[0]);
            setPoints[1].SetText(points[1]);
        }
    }
}