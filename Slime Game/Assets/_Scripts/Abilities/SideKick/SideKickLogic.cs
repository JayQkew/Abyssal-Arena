using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Abilities.SideKick
{
    public class SideKickLogic : Ability
    {
        public SideKick data;
        private Rigidbody2D _rb;
        [SerializeField] private SpriteRenderer sr;

        protected override void Start()
        {
            base.Start();
            _rb = GetComponent<Rigidbody2D>();
            //move to sidekick parent
            Transform newParent = transform.parent.parent.GetChild(transform.parent.parent.childCount - 1);
            transform.SetParent(newParent);
            sr.material = transform.parent.parent.GetChild(1).GetComponent<MeshRenderer>().material;

            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void Update()
        {
            Vector2 dir = inputHandler.moveInput;
            _rb.AddForce(dir * data.speed, ForceMode2D.Force);
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            transform.position = Vector3.zero;
            _rb.linearVelocity = Vector3.zero;
        }
    }
}