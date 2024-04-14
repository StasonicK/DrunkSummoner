using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Screens.GamePlay
{
    public class WordBar : MonoBehaviour
    {
        [SerializeField] private WordItem _wordItemPrefab;
        [SerializeField] private Transform _parent;

        private List<WordItem> _wordItems;

        private int _difference;

// TODO wrong letters count
        public void CreateEmptyWords(int max)
        {
            if (_wordItems != null)
                DestroyAll();

            _wordItems = new List<WordItem>();

            for (int i = 0; i < max; i++)
                _wordItems.Add(Instantiate(_wordItemPrefab, _parent));
        }

        public void FillNext() =>
            _wordItems.First(item => item.IsCatched == false).SetCatched();

        private void DestroyAll()
        {
            for (int i = 0; i < _wordItems.Count; i++)
            {
                if (_wordItems[i].IsCatched)
                    _wordItems[i].SetEmpty();

                Destroy(_wordItems[i].gameObject);
            }

            _wordItems = null;
        }
    }
}