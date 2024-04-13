using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        private Button _backButton;

        private void Awake()
        {
            _backButton = GetComponent<Button>();
            _backButton.onClick.AddListener(OnBackButtonClick);
        }

        private void OnBackButtonClick()
        {
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
        }
    }
}