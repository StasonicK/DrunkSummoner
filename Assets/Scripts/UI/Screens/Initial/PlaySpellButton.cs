using GamePlay.SummoningSpells;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class PlaySpellButton : MonoBehaviour
    {
        [SerializeField] private SummoningSpellId _summoningSpellId;

        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponent<Button>();
            _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick() =>
            GameStateManager.Instance.ToGamePlay(_summoningSpellId);
    }
}