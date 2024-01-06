using TMPro;
using UnityEngine;

namespace HealthView
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TextHealthBar : AbstractHealthBar
    {
        private TMP_Text _healthBarText;

        private void Awake()
        {
            _healthBarText = GetComponent<TMP_Text>();    
        }

        protected override void OnHealthChanged(float currentHealth, float maxHealth)
        {
            _healthBarText.text = $"{currentHealth}/{maxHealth}";
        }
    }
}