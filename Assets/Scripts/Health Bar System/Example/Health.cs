using System;
using UnityEngine;

public class Health : IHealthChangable
{
    private readonly int _maxValue;
    private int _currentValue;

    public Health(int currentValue, int maxValue)
    {
        _currentValue = currentValue;
        _maxValue = maxValue;
    }

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    public event Action<float, float> Changed;

    public void Heal(int value)
    {
        if(value <= 0) 
            throw new InvalidOperationException();

        _currentValue += value;

        ValueChanged();
    }

    public void Damage(int value)
    {
        if (value <= 0)
            throw new InvalidOperationException();

        _currentValue -= value;

        ValueChanged();
    }

    public void ValueChanged()
    {
        _currentValue = Mathf.Clamp( _currentValue, 0, _maxValue );
        Changed?.Invoke(_currentValue, _maxValue);
    }
}