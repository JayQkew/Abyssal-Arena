using System;
using Slime;
using Stats;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private void Update() {
        slider.maxValue = GetComponent<PlayerStats>().fuel;
        slider.value = GetComponent<Movement>().currFuel;
    }
}
