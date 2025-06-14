using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class GameModesComponent : MonoBehaviour
    {
        [SerializeField] private Toggle _commonModeToggle;
        [SerializeField] private Toggle _rthytmModeToggle;

        private void Awake()
        {
            _commonModeToggle.onValueChanged.AddListener(OnCommonModeToggleChanged);
            _rthytmModeToggle.onValueChanged.AddListener(OnRhythmModeToggleChanged);

            bool isCommonMode = GameStateManager.Instance.IsCommonMode;
            _commonModeToggle.isOn = isCommonMode;
            _rthytmModeToggle.isOn = !isCommonMode;
        }

        private void OnDestroy()
        {
            _commonModeToggle.onValueChanged.RemoveListener(OnCommonModeToggleChanged);
            _rthytmModeToggle.onValueChanged.RemoveListener(OnRhythmModeToggleChanged);
        }

        private void OnCommonModeToggleChanged(bool value)
        {
            if (value)
                GameStateManager.Instance.SetCommonMode();
        }

        private void OnRhythmModeToggleChanged(bool value)
        {
            if (value)
                GameStateManager.Instance.SetRhythmMode();
        }
    }
}