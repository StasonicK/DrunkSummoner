using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class PlayButton : MonoBehaviour
    {
        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponent<Button>();
            _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick() =>
            GameStateManager.Instance.ToGamePlay();
    }
}