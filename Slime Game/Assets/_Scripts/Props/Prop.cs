using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Props
{
    public class Prop : MonoBehaviour
    {
        private void Start()
        {
            int rand = Random.Range(0, transform.childCount);
            transform.GetChild(rand).gameObject.SetActive(true);
        }
    }
}
