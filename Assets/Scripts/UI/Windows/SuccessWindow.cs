using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class SuccessWindow : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Awake() =>
            _backButton.onClick.AddListener(OnBackButtonClick);

        private void OnBackButtonClick()
        {
            GameStateManager.Instance.ToInitialScreen();
            gameObject.SetActive(false);
        }
    }
}