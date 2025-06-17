using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class GameDifficultiesComponent : MonoBehaviour
    {
        [SerializeField] private Toggle _normalDifficultyToggle;
        [SerializeField] private Toggle _asianDifficultyToggle;

        private void Awake()
        {
            _normalDifficultyToggle.onValueChanged.AddListener(OnNormalDifficultyToggleChanged);
            _asianDifficultyToggle.onValueChanged.AddListener(OnAsianDifficultyToggleChanged);

            bool isNormalDifficulty = GameStateManager.Instance.IsNormalDifficulty;
            _normalDifficultyToggle.isOn = isNormalDifficulty;
            _asianDifficultyToggle.isOn = !isNormalDifficulty;
        }

        private void OnDestroy()
        {
            _normalDifficultyToggle.onValueChanged.RemoveListener(OnNormalDifficultyToggleChanged);
            _asianDifficultyToggle.onValueChanged.RemoveListener(OnAsianDifficultyToggleChanged);
        }

        private void OnNormalDifficultyToggleChanged(bool value)
        {
            if (value)
                GameStateManager.Instance.SetNormalDifficulty();
        }

        private void OnAsianDifficultyToggleChanged(bool value)
        {
            if (value)
                GameStateManager.Instance.SetAsianDifficulty();
        }
    }
}