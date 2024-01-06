using System;

public interface IHealthChangable
{
    public float CurrentValue { get; }
    public float MaxValue { get; }

    public event Action<float, float> Changed;
}