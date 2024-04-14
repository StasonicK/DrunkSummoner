using UnityEngine;

namespace UI.Screens.GamePlay.Progress
{
    public class WordsCounter : MonoBehaviour
    {
        private static WordsCounter _instance;

        private WordBar _wordBar;
        private int _totalCount;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _wordBar = GetComponent<WordBar>();
        }

        public static WordsCounter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<WordsCounter>();

                return _instance;
            }
        }

        public void Construct(int totalCount)
        {
            _totalCount = totalCount;
            ResetCount();
        }

        public void ResetCount() =>
            _wordBar.CreateEmptyWords(_totalCount);

        public void IncreaseCount() =>
            _wordBar.FillNext();
    }
}