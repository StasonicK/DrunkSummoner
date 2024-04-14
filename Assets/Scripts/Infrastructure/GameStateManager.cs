using System.Collections.Generic;
using System.Linq;
using GamePlay;
using GamePlay.SummoningSpells;
using StaticData;
using UI.Screens.GamePlay;
using UnityEngine;

namespace Infrastructure
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private WordsHolder _wordsHolder;
        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        private const string SummoningSpellsPath = "StaticData/SummoningSpells";

        private static GameStateManager _instance;

        private Dictionary<SummoningSpellId, SummoningSpellStaticData> _summoningSpells;
        private SummoningSpellStaticData _summoningSpellStaticData;
        private int _currentWordIndex;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            ToInitial();
        }

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GameStateManager>();

                return _instance;
            }
        }

        public void ToInitial()
        {
            _currentWordIndex = 0;
            _wordsHolder.HideAll();
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
            _summoningSpells = Resources
                .LoadAll<SummoningSpellStaticData>(SummoningSpellsPath)
                .ToDictionary(x => x.SummoningSpellId, x => x);
        }

        public void ToGamePlay(SummoningSpellId summoningSpellId)
        {
            _currentWordIndex = 0;
            _summoningSpellStaticData = _summoningSpells[summoningSpellId];
            ShowNextLetter();
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
            WordsCounter.Instance.Construct(_summoningSpellStaticData.WordMovements.Length);
        }

        public void LetterCatched()
        {
            WordsCounter.Instance.IncreaseCount();
            ShowNextLetter();
        }

        private void ShowNextLetter()
        {
            _wordsHolder.HideAll();

            if (_currentWordIndex > _summoningSpellStaticData.WordMovements.Length - 1)
                return;

            _wordsHolder.Show(_summoningSpellStaticData.WordMovements[_currentWordIndex]);
            _currentWordIndex++;
        }
    }
}