using UnityEngine;

namespace Abilities.Pull
{
    public class SuctionLogic : Ability
    {
        public Suction data;
        public ParticleSystem particles;
        public bool active;

        protected override void Start()
        {
            base.Start();
            inputHandler.onInflate.AddListener(OnInflate);
            inputHandler.onDeflate.AddListener(OnDeflate);
            SetRadius(data.radius);
        }

        private void SetRadius(float radius)
        {
            transform.localScale = new Vector3(radius * 2, radius * 2);
            ParticleSystem.ShapeModule shape = particles.shape;
            shape.radius = radius;
        }

        private void OnDeflate()
        {
            active = true;
            gui.SetActive(true);
        }

        private void OnInflate()
        {
            active = false;
            gui.SetActive(false);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!active) return;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (!other.CompareTag("Player") && !other.CompareTag("SoftBodyNode"))
            {
                if (rb == null) return;

                Vector2 dir = Vector2.ClampMagnitude((Vector2)transform.position - rb.position, 1);

                rb.AddForce(dir * data.force, ForceMode2D.Force);
            }
        }
    }
}