using System;
using Slime;
using UnityEngine;

namespace Abilities
{
    public class Ability : MonoBehaviour
    {
        protected InputHandler inputHandler;
        protected GameObject gui;

        protected virtual void Start()
        {
            inputHandler = transform.parent.parent.GetComponent<InputHandler>();
            gui = transform.GetChild(0).gameObject;
        }
    }
}
