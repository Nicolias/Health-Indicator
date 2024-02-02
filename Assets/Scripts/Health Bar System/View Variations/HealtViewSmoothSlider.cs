using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent (typeof(Slider))]
    public sealed class HealtViewSmoothSlider : AbstractHealthView
    {
        [SerializeField] private float _fillSpeed;

        private Slider _healthBarSlider;
        private Coroutine _fillHealthBar;

        protected override void OnInitialized()
        {
            _healthBarSlider = GetComponent<Slider>();
            _healthBarSlider.minValue = 0;
            _healthBarSlider.maxValue = MaxHealth;
        }

        protected override void OnHealthChanged(float currentHealth)
        {
            if (_fillHealthBar != null)
                StopCoroutine(_fillHealthBar);

            _fillHealthBar = StartCoroutine(FillHealthBar(currentHealth));
        }

        private IEnumerator FillHealthBar(float currentHealth)
        {
            float finalvalue = currentHealth / MaxHealth; 

            while (_healthBarSlider.normalizedValue != finalvalue)
            {
                _healthBarSlider.normalizedValue = Mathf.MoveTowards
                (
                    _healthBarSlider.normalizedValue,
                    finalvalue,
                    _fillSpeed * Time.deltaTime
                );
                yield return null;
            }
        }
    }
}