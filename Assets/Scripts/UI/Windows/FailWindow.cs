using Audio;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class FailWindow : BaseWindow
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnBackButtonClick()
        {
            AudioManager.Instance.PlayAudio(AudioTrack.CloseWindowSoundFx);
            GameStateManager.Instance.ToInitialScreen();
            Hide();
        }

        private void OnRestartButtonClick()
        {
            GameStateManager.Instance.RestartGamePlay();
            Hide();
        }
    }
}