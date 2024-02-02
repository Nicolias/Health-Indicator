using System;
using UnityEngine;

public abstract class AbstractHealth
{
    private readonly float _maxValue;
    private float _currentValue;

    public AbstractHealth(float currentValue, float maxValue)
    {
        _currentValue = currentValue;
        _maxValue = maxValue;
    }

    public float MaxValue => _maxValue;

    public event Action<float> Changed;

    public void Heal(int value)
    {
        if(value <= 0) 
            throw new InvalidOperationException();

        _currentValue += value;

        OnValueChanged();
    }

    public void Damage(int value)
    {
        if (value <= 0)
            throw new InvalidOperationException();

        _currentValue -= value;

        OnValueChanged();
    }

    public void OnValueChanged()
    {
        _currentValue = Mathf.Clamp( _currentValue, 0, _maxValue );
        Changed?.Invoke(_currentValue);
    }
}