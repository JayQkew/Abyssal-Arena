using System;
using Slime;
using UnityEngine;

namespace Props
{
    public class Energy : SpawnObject
    {
        [SerializeField] public float energy;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Movement>().AirRefill(energy);
                Use();
            }
        }
    }
}
