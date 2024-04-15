using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay
{
    public class BackButton : MonoBehaviour
    {
        private Button _backButton;

        private void Awake()
        {
            _backButton = GetComponent<Button>();
            _backButton.onClick.AddListener(OnBackButtonClick);
        }

        private void OnBackButtonClick()
        {
            GameStateManager.Instance.ToInitialScreen();
        }
    }
}