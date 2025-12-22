using System;
using AppStates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 spawnPoint;
    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (AppState.Instance == null) return;
        
        AppState.Instance.gameplayState.matchState.onScore.AddListener(Respawn);
        spawnPoint = transform.position;
    }

    private void OnDestroy() {
        if (AppState.Instance == null) return;
        
        AppState.Instance.gameplayState.matchState.onScore.RemoveListener(Respawn);
    }

    private void Respawn() {
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;
        _rb.rotation = 0f;
        transform.position = spawnPoint;
    }
}