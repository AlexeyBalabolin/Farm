using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GrownBar : MonoBehaviour
    {
        public Image ImageCurrent;
        public void SetValue(float current, float max) => ImageCurrent.fillAmount = current / max;
    }
}

