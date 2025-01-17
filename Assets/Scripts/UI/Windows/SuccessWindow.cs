﻿using Audio;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class SuccessWindow : BaseWindow
    {
        [SerializeField] private Button _backButton;

        private void Awake() =>
            _backButton.onClick.AddListener(OnBackButtonClick);

        private void OnBackButtonClick()
        {
            AudioManager.Instance.PlayAudio(AudioTrack.CloseWindowSoundFx);
            GameStateManager.Instance.ToInitialScreen();
            Hide();
        }
    }
}