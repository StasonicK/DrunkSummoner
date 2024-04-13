using UnityEngine;

namespace UI.Screens.GamePlay
{
    public class WordCounter : MonoBehaviour
    {
        private static WordCounter _instance;

        private WordBar _wordBar;
        private int _totalCount;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _wordBar = GetComponent<WordBar>();
        }

        public static WordCounter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<WordCounter>();

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