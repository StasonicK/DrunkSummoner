using GamePlay.Words;
using UnityEngine;

namespace GamePlay
{
    public class WordsHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _word;

        public void Show(WordMovement wordMovement)
        {
            switch (wordMovement)
            {
                case StraightLineWordMovement:
                case DiagonalWordMovement:
                    _word.SetActive(true);
                    break;
            }
        }

        public void HideAll()
        {
            _word.SetActive(false);
        }
    }
}