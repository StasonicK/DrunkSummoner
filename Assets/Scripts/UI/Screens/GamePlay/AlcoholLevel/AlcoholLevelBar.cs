using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay.AlcoholLevel
{
    public class AlcoholLevelBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Awake() =>
            _slider.value = _slider.maxValue;

        public float MaxSliderValue => _slider.maxValue;

        public void SetValue(float current, float max) =>
            _slider.value = current / max;
    }
}