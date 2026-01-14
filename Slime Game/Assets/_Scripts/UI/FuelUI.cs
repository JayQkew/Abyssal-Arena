using Slime;
using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FuelUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private PlayerStats _playerStats;

        private void Start()
        {
            _playerStats = GetComponent<SlimeStats>().Stats;
        }

        private void Update() {
            slider.maxValue = _playerStats.Fuel;
            slider.value = GetComponent<Movement>().currFuel;
        }
    }
}
