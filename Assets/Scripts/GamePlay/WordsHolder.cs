using GamePlay.Words;
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

        public void Show(WordMovement wordMovement, Sprite sprite)
        {
            switch (wordMovement)
            {
                case StraightLineWordMovement:
                    _straightLineWordMovement.gameObject.SetActive(true);
                    _straightLineWordMovement.gameObject.GetComponent<WordSignSetter>().Set(sprite);
                    break;
                case DiagonalWordMovement:
                    _diagonalWordMovement.gameObject.SetActive(true);
                    _straightLineWordMovement.gameObject.GetComponent<WordSignSetter>().Set(sprite);
                    break;
            }
        }

        // private void SetAudio(AudioClip)

        public void HideAll()
        {
            _straightLineWordMovement.gameObject.SetActive(false);
            _diagonalWordMovement.gameObject.SetActive(false);
        }
    }
}