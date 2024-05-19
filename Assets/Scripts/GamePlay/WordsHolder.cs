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
                    _straightLineWordMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _straightLineWordMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    break;
                case DiagonalWordMovement:
                    _straightLineWordMovement.gameObject.GetComponent<WordSignSetter>().Set(sprite);
                    _diagonalWordMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
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