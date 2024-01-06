using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent (typeof(Slider))]
    public sealed class SmoothSliderHealthBar : AbstractHealthBar
    {
        [SerializeField] private float _fillSpeed;

        private Slider _healthBarSlider;

        private void Awake()
        {
            _healthBarSlider = GetComponent<Slider>();
        }

        protected override void OnHealthChanged(float currentHealth, float maxHealth)
        {
            StartCoroutine(FillHealthBar(currentHealth, maxHealth));
        }

        private IEnumerator FillHealthBar(float currentHealth, float maxHealth)
        {
            float finalValue = currentHealth / maxHealth;

            while (_healthBarSlider.value != finalValue)
            {
                _healthBarSlider.value = Mathf.MoveTowards(_healthBarSlider.value, finalValue, _fillSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}