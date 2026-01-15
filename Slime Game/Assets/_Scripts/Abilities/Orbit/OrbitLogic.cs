using System;
using UnityEngine;

namespace Abilities.Orbit
{
    public class OrbitLogic : Ability
    {
        public Orbit data;
        public float dir = 1;
        protected override void Start()
        {
            base.Start();
            inputHandler.onDash.AddListener(OnDash);
        }

        private void Update()
        {
            transform.Rotate(0, 0,  data.speed* dir * Time.deltaTime);
        }

        private void OnDash()
        {
            dir *= -1;
        }
    }
}
