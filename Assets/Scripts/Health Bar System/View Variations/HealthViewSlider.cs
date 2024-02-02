using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent(typeof(Slider))]
    public sealed class HealthViewSlider : AbstractHealthView
    {
        private Slider _healthBarSlider;

        protected override void OnInitialized()
        {
            _healthBarSlider = GetComponent<Slider>();
            _healthBarSlider.maxValue = MaxHealth;
        }

        protected override void OnHealthChanged(float currentHealth)
        {
            _healthBarSlider.value = currentHealth;
        }
    }
}