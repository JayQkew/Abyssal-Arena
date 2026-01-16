using System;
using UnityEngine;

namespace Props
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class SpawnObject : MonoBehaviour
    {
        public bool active;
        public Rigidbody2D rb;
        public CircleCollider2D col;
        [SerializeField] protected SpriteRenderer sr;
        [SerializeField] private ParticleSystem particles;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public virtual void Respawn(Vector2 pos)
        {
            transform.position = pos;
            rb.linearVelocity = Vector2.zero;

            Color c = sr.color;
            sr.color = new Color(c.r, c.g, c.b, 1f);

            col.enabled = true;
            active = true;
        }

        protected void Use()
        {
            particles.Play();
            Color c = sr.color;
            sr.color = new Color(c.r, c.g, c.b, 0f);

            col.enabled = false;
            active = false;
        }
    }
}