using System;

namespace UI
{
    public interface IBar
    {
        float CurrentValue { get; set; }
        float MaxValue { get; set; }

        event Action OnValueChanged;
    }
}

