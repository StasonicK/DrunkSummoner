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
			if (_commonModeToggle == null || _rthytmModeToggle == null)
				return;

			// Set initial UI state without invoking listeners
			bool isCommonMode = GameStateManager.Instance.IsCommonMode;
			_commonModeToggle.SetIsOnWithoutNotify(isCommonMode);
			_rthytmModeToggle.SetIsOnWithoutNotify(!isCommonMode);

			// Add listeners after initial setup to avoid immediate callbacks
			_commonModeToggle.onValueChanged.AddListener(OnCommonModeToggleChanged);
			_rthytmModeToggle.onValueChanged.AddListener(OnRhythmModeToggleChanged);
		}

		private void OnDestroy()
		{
			if (_commonModeToggle != null)
				_commonModeToggle.onValueChanged.RemoveListener(OnCommonModeToggleChanged);

			if (_rthytmModeToggle != null)
				_rthytmModeToggle.onValueChanged.RemoveListener(OnRhythmModeToggleChanged);
		}

		private void OnCommonModeToggleChanged(bool value)
		{
			// When turned on: ensure the other toggle is off (without notifying) and set game state once.
			if (value)
			{
				if (_rthytmModeToggle.isOn)
					_rthytmModeToggle.SetIsOnWithoutNotify(false);

				if (!GameStateManager.Instance.IsCommonMode)
					GameStateManager.Instance.SetCommonMode();

				return;
			}

			// When turned off: if the other toggle is also off (Allow Switch Off = true), enforce the other on.
			if (!_rthytmModeToggle.isOn)
				_rthytmModeToggle.SetIsOnWithoutNotify(true);

			// Ensure game state reflects the active toggle
			if (GameStateManager.Instance.IsCommonMode)
				GameStateManager.Instance.SetRhythmMode();
		}

		private void OnRhythmModeToggleChanged(bool value)
		{
			if (value)
			{
				if (_commonModeToggle.isOn)
					_commonModeToggle.SetIsOnWithoutNotify(false);

				if (GameStateManager.Instance.IsCommonMode)
					GameStateManager.Instance.SetRhythmMode();

				return;
			}

			if (!_commonModeToggle.isOn)
				_commonModeToggle.SetIsOnWithoutNotify(true);

			if (!GameStateManager.Instance.IsCommonMode)
				GameStateManager.Instance.SetCommonMode();
		}
	}
}