using System;
using Slime;
using Stats;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats playerStats;
    private void Update() {
        slider.maxValue = playerStats.Fuel;
        slider.value = GetComponent<Movement>().currFuel;
    }
}
