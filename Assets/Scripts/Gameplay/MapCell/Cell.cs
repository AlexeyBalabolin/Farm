using System;
using UnityEngine;

namespace Gameplay
{
    public class Cell : MonoBehaviour, IClickable
    {
        public event Action OnClick;
        public event Action OnChanged;
        public void Click() => OnClick?.Invoke();
    }
}

