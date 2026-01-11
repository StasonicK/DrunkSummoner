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
			if (_normalDifficultyToggle == null || _asianDifficultyToggle == null)
				return;

			// Initialize UI without invoking listeners
			bool isNormalDifficulty = GameStateManager.Instance.IsNormalDifficulty;
			_normalDifficultyToggle.SetIsOnWithoutNotify(isNormalDifficulty);
			_asianDifficultyToggle.SetIsOnWithoutNotify(!isNormalDifficulty);

			// Add listeners after initial setup
			_normalDifficultyToggle.onValueChanged.AddListener(OnNormalDifficultyToggleChanged);
			_asianDifficultyToggle.onValueChanged.AddListener(OnAsianDifficultyToggleChanged);
		}

		private void OnDestroy()
		{
			if (_normalDifficultyToggle != null)
				_normalDifficultyToggle.onValueChanged.RemoveListener(OnNormalDifficultyToggleChanged);

			if (_asianDifficultyToggle != null)
				_asianDifficultyToggle.onValueChanged.RemoveListener(OnAsianDifficultyToggleChanged);
		}

		private void OnNormalDifficultyToggleChanged(bool value)
		{
			if (_normalDifficultyToggle == null || _asianDifficultyToggle == null)
				return;

			if (value)
			{
				if (_asianDifficultyToggle.isOn)
					_asianDifficultyToggle.SetIsOnWithoutNotify(false);

				if (!GameStateManager.Instance.IsNormalDifficulty)
					GameStateManager.Instance.SetNormalDifficulty();

				return;
			}

			// If the other toggle is also off (Allow Switch Off = true), enforce the other on.
			if (!_asianDifficultyToggle.isOn)
				_asianDifficultyToggle.SetIsOnWithoutNotify(true);

			if (GameStateManager.Instance.IsNormalDifficulty)
				GameStateManager.Instance.SetAsianDifficulty();
		}

		private void OnAsianDifficultyToggleChanged(bool value)
		{
			if (_normalDifficultyToggle == null || _asianDifficultyToggle == null)
				return;

			if (value)
			{
				if (_normalDifficultyToggle.isOn)
					_normalDifficultyToggle.SetIsOnWithoutNotify(false);

				if (GameStateManager.Instance.IsNormalDifficulty)
					GameStateManager.Instance.SetAsianDifficulty();

				return;
			}

			if (!_normalDifficultyToggle.isOn)
				_normalDifficultyToggle.SetIsOnWithoutNotify(true);

			if (!GameStateManager.Instance.IsNormalDifficulty)
				GameStateManager.Instance.SetNormalDifficulty();
		}
	}
}