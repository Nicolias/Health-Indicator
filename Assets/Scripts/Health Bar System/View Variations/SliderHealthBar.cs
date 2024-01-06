using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent(typeof(Slider))]
    public sealed class SliderHealthBar : AbstractHealthBar
    {
        private Slider _healthBarSlider;

        private void Awake()
        {
            _healthBarSlider = GetComponent<Slider>();
        }

        protected override void OnHealthChanged(float currentHealth, float maxHealth)
        {
            _healthBarSlider.value = currentHealth / maxHealth;
        }
    }
}