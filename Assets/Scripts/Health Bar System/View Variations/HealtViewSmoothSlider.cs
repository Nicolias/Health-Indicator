using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    [RequireComponent (typeof(Slider))]
    public sealed class HealtViewSmoothSlider : HealthViewSlider
    {
        [SerializeField] private float _fillSpeed;

        private Coroutine _fillHealthBar;

        protected override void OnHealthChanged(float currentHealth)
        {
            if (_fillHealthBar != null)
                StopCoroutine(_fillHealthBar);

            _fillHealthBar = StartCoroutine(FillHealthBar(currentHealth));
        }

        private IEnumerator FillHealthBar(float currentHealth)
        {
            float finalvalue = currentHealth / MaxHealth; 

            while (HealthBarSlider.normalizedValue != finalvalue)
            {
                HealthBarSlider.normalizedValue = Mathf.MoveTowards
                (
                    HealthBarSlider.normalizedValue,
                    finalvalue,
                    _fillSpeed * Time.deltaTime
                );

                yield return null;
            }
        }
    }
}