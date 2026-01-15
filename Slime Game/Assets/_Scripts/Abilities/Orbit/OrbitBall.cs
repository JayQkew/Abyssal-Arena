using System;
using UnityEngine;
using Utilities;

namespace Abilities.Orbit
{
    public class OrbitBall : MonoBehaviour
    {
        [SerializeField] private Orbit data;
        private Timer _timer;
        private CircleCollider2D _col;
        private SpriteRenderer _renderer;

        private void Start()
        {
            _col = GetComponent<CircleCollider2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _timer = new Timer(data.recoveryTime);
        }

        private void Update()
        {
            _timer.Update();
            if (_timer.IsFinished)
            {
                _col.isTrigger = false;
                _renderer.color = new Color(1, 1, 1, 1);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _renderer.color = new Color(1, 1, 1, 0.15f);
            _timer.Reset();
            _col.isTrigger = true;
            
            other.rigidbody.AddForceAtPosition(other.GetContact(0).normal * -data.hitForce, other.contacts[0].point, ForceMode2D.Impulse);
        }
    }
}
