﻿using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay.Timer
{
    public class TimeLimitBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetValue(float current, float max) =>
            _slider.value = current / max;
    }
}