using GamePlay;
using UnityEngine;

namespace Infrastructure
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private WordsHolder _wordsHolder;
        [SerializeField] private GameObject _initialScreen;
        [SerializeField] private GameObject _gamePlayScreen;

        private void Awake()
        {
            _wordsHolder.gameObject.SetActive(false);
            _initialScreen.SetActive(true);
            _gamePlayScreen.SetActive(false);
        }
    }
}