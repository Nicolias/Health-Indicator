using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent(typeof(Slider))]
    public class HealthViewSlider : AbstractHealthView
    {
        protected Slider HealthBarSlider;

        protected sealed override void OnInitialized()
        {
            HealthBarSlider = GetComponent<Slider>();

            HealthBarSlider.minValue = 0;
            HealthBarSlider.value = MaxHealth;
            HealthBarSlider.maxValue = MaxHealth;
        }

        protected override void OnHealthChanged(float currentHealth)
        {
            HealthBarSlider.value = currentHealth;
        }
    }
}