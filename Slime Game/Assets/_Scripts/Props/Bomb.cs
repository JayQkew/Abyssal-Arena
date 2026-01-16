using System;
using UnityEngine;
using Utilities;

namespace Props
{
    public class Bomb : SpawnObject
    {
        private static readonly int GlowRadius = Shader.PropertyToID("_GlowRadius");
        [SerializeField] private float radius;
        [SerializeField] private float explosiveForce;
        [SerializeField] private Countdown countdown;
        [SerializeField] private Material flashMat;
        private Material _flashMat;
        private bool _touched;

        protected void Start()
        {
            _flashMat = new Material(flashMat);
            _flashMat.SetFloat(GlowRadius, 0);
            sr.material = _flashMat;
        }

        public override void Respawn(Vector2 pos)
        {
            base.Respawn(pos);
            countdown.Reset();
            _flashMat.SetFloat(GlowRadius, 0);
            _touched = false;
        }

        private void Update()
        {
            if (_touched)
            {
                Flash();
                countdown.Update();
                if (countdown.IsFinished)
                {
                    Explode();
                    Use();
                    _touched = false;
                }
            }
        }
        
        private void Flash() {
            // flash speed increases as countdown decreases
            float flashSpeed = Mathf.Lerp(0.5f, 10f, 1 - countdown.Progress);
            float glowStrength = Mathf.Abs(Mathf.Sin((countdown.maxTime - countdown.currTime) * flashSpeed));
            _flashMat.SetFloat(GlowRadius, glowStrength * 1.5f);
        }

        private void Explode()
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0);
            foreach (RaycastHit2D h in hit)
            {
                Rigidbody2D rb = h.collider.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 dir = rb.position - (Vector2)transform.position;
                    rb.AddForce(explosiveForce * dir, ForceMode2D.Impulse);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ball"))
            {
                _touched = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
