using GamePlay;
using UI.Screens.GamePlay;
using UnityEngine;

namespace Infrastructure
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private WordsHolder _wordsHolder;
        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        private static GameStateManager _instance;

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
        }

        public void ToGamePlay()
        {
            _wordsHolder.Show();
            _initialScreen.SetActive(false);
            _gamePlayScreen.SetActive(true);
            WordCounter.Instance.Construct(2); // test
        }
    }
}