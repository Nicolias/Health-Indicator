using UnityEngine;

namespace HealthView
{
    public abstract class AbstractHealthBar : MonoBehaviour
    {
        private IHealthChangable _health;

        public void Initialize(IHealthChangable health)
        {
            _health = health;

            _health.Changed += OnHealthChanged;
            OnHealthChanged(health.CurrentValue, health.MaxValue);
        }

        private void OnDestroy()
        {
            _health.Changed -= OnHealthChanged;
        }

        protected abstract void OnHealthChanged(float currentHealth, float maxHealth);
    }
}
