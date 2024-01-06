using HealthView;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarExample : MonoBehaviour
{
    [SerializeField] private List<AbstractHealthBar> _healthBars;

    [SerializeField] private int _damageValue;
    [SerializeField] private int _healValue;

    private Health _health;

    private void Awake()
    {
        _health = new Health(100, 100);   
    }
    
    private void Start()
    {
        _healthBars.ForEach(bar => bar.Initialize(_health));
    }

    public void Heal()
    {
        _health.Heal(_healValue);
    }

    public void Damage()
    {
        _health.Damage(_damageValue);
    }
}
