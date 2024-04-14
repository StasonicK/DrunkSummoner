using GamePlay.Words.Movement;
using UnityEngine;

namespace GamePlay
{
    public class WordsHolder : MonoBehaviour
    {
        [SerializeField] private StraightLineWordMovement _straightLineWordMovement;
        [SerializeField] private DiagonalWordMovement _diagonalWordMovement;

        private void Awake() =>
            HideAll();

        public void Show(WordMovement wordMovement)
        {
            switch (wordMovement)
            {
                case StraightLineWordMovement:
                    _straightLineWordMovement.gameObject.SetActive(true);
                    break;
                case DiagonalWordMovement:
                    _diagonalWordMovement.gameObject.SetActive(true);
                    break;
            }
        }

        public void HideAll()
        {
            _straightLineWordMovement.gameObject.SetActive(false);
            _diagonalWordMovement.gameObject.SetActive(false);
        }
    }
}