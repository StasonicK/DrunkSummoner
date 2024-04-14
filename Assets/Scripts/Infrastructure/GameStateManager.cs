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
            _wordsHolder.HideAll();
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
            _summoningSpells = Resources
                .LoadAll<SummoningSpellStaticData>(SummoningSpellsPath)
                .ToDictionary(x => x.SummoningSpellId, x => x);
        }

        public void ToGamePlay()
        {
            _summoningSpellStaticData = _summoningSpells[SummoningSpellId.PotatoBag];
            _wordsHolder.Show(_summoningSpellStaticData.WordMovements[0]);
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
            WordCounter.Instance.Construct(2); // test
        }

        public void WordCatched()
        {
            WordCounter.Instance.IncreaseCount();
        }
    }
}