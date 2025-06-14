using System.Collections.Generic;
using System.Linq;
using Audio;
using GamePlay;
using GamePlay.SummonedObjects;
using GamePlay.SummoningSpells;
using StaticData;
using UI.Screens.GamePlay.AlcoholLevel;
using UI.Screens.GamePlay.Economy;
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
        [SerializeField] private SuccessWindow _successWindow;
        [SerializeField] private float _maxWordTime = 10f;

        private const string SummoningSpellsPath = "StaticData/SummoningSpells";

        private static GameStateManager _instance;

        private Dictionary<SummonedObjectsId, SummoningSpellStaticData> _summoningSpells;
        private SummoningSpellStaticData _summoningSpellStaticData;
        private int _currentWordIndex;

        public bool IsCommonMode { private set; get; } = true;

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
            _currentWordIndex = 0;
            _wordsHolder.HideAll();
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
            _failWindow.Hide();
            _successWindow.Hide();
            Summoner.Instance.OffAll();
            _summoningSpells = Resources
                .LoadAll<SummoningSpellStaticData>(SummoningSpellsPath)
                .ToDictionary(x => x.SummonedObjectsId, x => x);
        }

        public void StartGamePlay(SummonedObjectsId summonedObjectsId)
        {
            _failWindow.Hide();
            _successWindow.Hide();
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
            _currentWordIndex = 0;
            _summoningSpellStaticData = _summoningSpells[summonedObjectsId];
            ShowNextWord();
            WordsCounter.Instance.Construct(_summoningSpellStaticData.WordMovements.Length);
            Timer.Instance.Construct(_maxWordTime);
            Timer.Instance.Start();
            AlcoholLevel.Instance.Start();
            Money.Instance.Start();
            DrinkButton.Instance.On();
            AudioManager.Instance.SetCreatedObjectAudioClip(_summoningSpellStaticData.SummonedObjectsId);
        }

        public void RestartGamePlay()
        {
            _failWindow.Hide();
            _successWindow.Hide();
            _currentWordIndex = 0;
            ShowNextWord();
            WordsCounter.Instance.Construct(_summoningSpellStaticData.WordMovements.Length);
            Timer.Instance.Construct(_maxWordTime);
            Timer.Instance.Start();
            AlcoholLevel.Instance.Restart();
            Money.Instance.Restart();
            DrinkButton.Instance.On();
        }

        public void WordCatched()
        {
            AudioManager.Instance.PlayWord();
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
            AudioManager.Instance.PlayCreatedObject();
            AudioManager.Instance.PlayAudio(AudioTrack.WinSoundFx);
            _wordsHolder.StopCurrentWord();
            Timer.Instance.Stop();
            AlcoholLevel.Instance.Stop();
            AlcoholLevel.Instance.SetPreviousLevel();
            DrinkButton.Instance.Off();
            ShowSuccessWindow();
            Money.Instance.AddMoney(_summoningSpellStaticData.MoneyReward);
            Money.Instance.SetPreviousMoneyCount();
            Summoner.Instance.OffAll();
            Summoner.Instance.Summon(_summoningSpellStaticData.SummonedObjectsId);
        }

        private void ShowNextWord()
        {
            _wordsHolder.StopCurrentWord();
            AudioManager.Instance.SetWordAudioClip(_summoningSpellStaticData.AudioClips[_currentWordIndex]);
            _wordsHolder.SetCurrentWord(_summoningSpellStaticData.WordMovements[_currentWordIndex],
                _summoningSpellStaticData.Signs[_currentWordIndex]);
            _wordsHolder.SetFadingMoveCurrentWord();
            _currentWordIndex++;
        }

        public void ShowFailWindow()
        {
            AudioManager.Instance.PlayAudio(AudioTrack.FailSoundFx);
            _wordsHolder.StopCurrentWord();
            Timer.Instance.Stop();
            AlcoholLevel.Instance.Stop();
            DrinkButton.Instance.Off();
            _failWindow.Show();
            AlcoholLevelDroppedZeroAnimator.Instance.StopRotation();
        }

        public void AlcoholLevelDroppedZero()
        {
            AlcoholLevelDroppedZeroAnimator.Instance.StartRotation();
            _wordsHolder.SetFadingStopCurrentWord();
        }

        public void AlcoholLevelIncreased()
        {
            AlcoholLevelDroppedZeroAnimator.Instance.StopRotation();
            _wordsHolder.SetFadingMoveCurrentWord();
        }

        private void ShowSuccessWindow()
        {
            _wordsHolder.StopCurrentWord();
            Timer.Instance.Stop();
            AlcoholLevel.Instance.Stop();
            DrinkButton.Instance.Off();
            _successWindow.Show();
            AlcoholLevelDroppedZeroAnimator.Instance.StopRotation();
        }

        public void SetCommonMode() =>
            IsCommonMode = true;

        public void SetRhythmMode() =>
            IsCommonMode = false;
    }
}