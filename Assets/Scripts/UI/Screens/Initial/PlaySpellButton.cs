using GamePlay.SummoningSpells;
using Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class PlaySpellButton : MonoBehaviour
    {
        [FormerlySerializedAs("_summoningSpellId")] [SerializeField] private SummonedObjectsId _summonedObjectsId;

        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponent<Button>();
            _playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick() =>
            GameStateManager.Instance.StartGamePlay(_summonedObjectsId);
    }
}