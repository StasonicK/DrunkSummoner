using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponent<Button>();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
        }

        private void OnPlayButtonClick()
        {
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
        }
    }
}