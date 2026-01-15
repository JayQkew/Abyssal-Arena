using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Abilities.Shoot
{
    public class ShootLogic : Ability
    {
        public Shoot data;
        public LineRenderer lineRenderer;
        public LayerMask layerMask;
        public float lineWidth;
        public Timer timer;

        protected override void Start()
        {
            base.Start();
            inputHandler.onDash.AddListener(OnDash);
            
            // Ensure the line is off at the start
            lineRenderer.enabled = false; 
        }

        private void Update()
        {
            timer.Update();

            if (!timer.IsFinished)
            {
                // FIX 1: Keep the start of the laser attached to the player 
                // even if they move while the laser is fading.
                lineRenderer.SetPosition(0, Vector3.zero);

                // FIX 2: Invert logic so it shrinks over time (1 -> 0) 
                // instead of growing (0 -> 1).
                float currentWidth = lineWidth * (1f - timer.Progress);
                lineRenderer.startWidth = currentWidth;
                lineRenderer.endWidth = currentWidth;
            }
            else
            {
                // Optimization: Disable the renderer when not in use 
                // instead of just setting width to 0.
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
        }

        private void OnDash()
        {
            Vector2 dir = inputHandler.moveInput;
            
            // Handle case where there is no input (dir is zero)
            if (dir == Vector2.zero) dir = transform.up;

            Vector2 endPoint = dir * data.range;
            RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, dir, data.range, layerMask);

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, endPoint);
            
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            
            timer.Reset();
            
            if (hit.collider != null && hit.rigidbody != null)
            {
                bool isIgnoredTag = hit.collider.CompareTag("Player") || hit.collider.CompareTag("SoftBodyNode");

                if (!isIgnoredTag)
                {
                    hit.rigidbody.AddForceAtPosition(data.force * dir, hit.point, ForceMode2D.Impulse);
                }
            }
        }
    }
}