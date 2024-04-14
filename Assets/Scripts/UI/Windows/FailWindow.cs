using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class FailWindow : MonoBehaviour
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
            GameStateManager.Instance.ToInitialScreen();
            gameObject.SetActive(false);
        }

        private void OnRestartButtonClick()
        {
            GameStateManager.Instance.RestartGamePlay();
            gameObject.SetActive(false);
        }
    }
}