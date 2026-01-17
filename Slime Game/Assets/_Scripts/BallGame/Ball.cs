using System;
using AppStates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BallGame
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Vector2 spawnPoint;
        private Rigidbody2D _rb;
        private AudioSource _audioSource;
        [SerializeField] private float collisionSoundCooldown = 0.1f;
        [SerializeField] private float minImpactForce = 1.2f;

        private float _lastSoundTime;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();
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

        private void Respawn(int[] i) {
            _rb.linearVelocity = Vector2.zero;
            _rb.angularVelocity = 0f;
            _rb.rotation = 0f;
            transform.position = spawnPoint;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Time.time - _lastSoundTime < collisionSoundCooldown)
                return;

            if (other.relativeVelocity.magnitude < minImpactForce)
                return;

            _lastSoundTime = Time.time;

            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.Play();
        }
    }
}