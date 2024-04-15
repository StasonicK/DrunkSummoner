using System.Collections.Generic;
using System.Linq;
using GamePlay;
using GamePlay.SummoningSpells;
using StaticData;
using UI.Screens.GamePlay.Progress;
using UI.Screens.GamePlay.Timer;
using UI.Windows;
using UnityEngine;

namespace Infrastructure
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private WordsHolder _wordsHolder;

        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        [SerializeField] private FailWindow _failWindow;

        [SerializeField] private float _maxWordTime = 10f;

        private const string SummoningSpellsPath = "StaticData/SummoningSpells";

        private static GameStateManager _instance;

        private Dictionary<SummoningSpellId, SummoningSpellStaticData> _summoningSpells;
        private SummoningSpellStaticData _summoningSpellStaticData;
        private int _currentWordIndex;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            ToInitialScreen();
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

        public void ToInitialScreen()
        {
            _currentWordIndex = 1;
            _wordsHolder.HideAll();
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
            _summoningSpells = Resources
                .LoadAll<SummoningSpellStaticData>(SummoningSpellsPath)
                .ToDictionary(x => x.SummoningSpellId, x => x);
        }

        public void StartGamePlay(SummoningSpellId summoningSpellId)
        {
            _currentWordIndex = 0;
            _summoningSpellStaticData = _summoningSpells[summoningSpellId];
            ShowNextWord();
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
            WordsCounter.Instance.Construct(_summoningSpellStaticData.WordMovements.Length);
            Timer.Instance.Construct(_maxWordTime);
            Timer.Instance.Start();
        }

        public void RestartGamePlay()
        {
            _currentWordIndex = 0;
            ShowNextWord();
            // _initialScreen.SetActive(false);
            // _gamePlayScreen.SetActive(true);
            WordsCounter.Instance.Construct(_summoningSpellStaticData.WordMovements.Length);
            Timer.Instance.Construct(_maxWordTime);
            Timer.Instance.Start();
        }

        public void WordCatched()
        {
            WordsCounter.Instance.IncreaseCount();

            if (_currentWordIndex < _summoningSpellStaticData.WordMovements.Length)
            {
                Timer.Instance.Construct(_maxWordTime);
                ShowNextWord();
            }
            else
            {
                Success();
            }
        }

        private void Success()
        {
            _wordsHolder.HideAll();
            Timer.Instance.Stop();
            // TODO show summoned item/creature
            // TODO add money
        }

        private void ShowNextWord()
        {
            _wordsHolder.HideAll();
            _wordsHolder.Show(_summoningSpellStaticData.WordMovements[_currentWordIndex]);
            _currentWordIndex++;
        }

        public void ShowFailWindow()
        {
            _wordsHolder.HideAll();
            _failWindow.gameObject.SetActive(true);
        }
    }
}