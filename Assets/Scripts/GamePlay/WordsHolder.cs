using GamePlay.Words;
using GamePlay.Words.Movement;
using GamePlay.Words.Movement.AnyDirection;
using UnityEngine;

namespace GamePlay
{
    public class WordsHolder : MonoBehaviour
    {
        [SerializeField] private StraightLineWordMovement _straightLineWordMovement;
        [SerializeField] private DiagonalWordMovement _diagonalWordMovement;
        [SerializeField] private FullRandomDirectionMovement _fullRandomDirectionMovement;
        [SerializeField] private LeftSideDirectionMovement _leftSideDirectionMovement;
        [SerializeField] private LeftSideRandomAngleDirectionMovement _leftSideRandomAngleDirectionMovement;
        [SerializeField] private RandomSideDirectionMovement _randomSideDirectionMovement;
        [SerializeField] private RightSideDirectionMovement _rightSideDirectionMovement;
        [SerializeField] private RightSideRandomRotationDirectionMovement _rightSideRandomRotationDirectionMovement;

        private void Awake() =>
            HideAll();

        public void Show(WordMovement wordMovement, Sprite sprite)
        {
            switch (wordMovement)
            {
                case StraightLineWordMovement:
                    _straightLineWordMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _straightLineWordMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _straightLineWordMovement.SetMove();
                    break;
                case DiagonalWordMovement:
                    _diagonalWordMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _diagonalWordMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _diagonalWordMovement.SetMove();
                    break;
                case FullRandomDirectionMovement:
                    _fullRandomDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _fullRandomDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _fullRandomDirectionMovement.ChangeMoveDirection();
                    _fullRandomDirectionMovement.SetMove();
                    break;
                case LeftSideDirectionMovement:
                    _leftSideDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _leftSideDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _leftSideDirectionMovement.ChangeMoveDirection();
                    _leftSideDirectionMovement.SetMove();
                    break;
                case LeftSideRandomAngleDirectionMovement:
                    _leftSideRandomAngleDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _leftSideRandomAngleDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _leftSideRandomAngleDirectionMovement.ChangeMoveDirection();
                    _leftSideRandomAngleDirectionMovement.SetMove();
                    break;
                case RandomSideDirectionMovement:
                    _randomSideDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _randomSideDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _randomSideDirectionMovement.ChangeMoveDirection();
                    _randomSideDirectionMovement.SetMove();
                    break;
                case RightSideDirectionMovement:
                    _rightSideDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _rightSideDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _rightSideDirectionMovement.ChangeMoveDirection();
                    _rightSideDirectionMovement.SetMove();
                    break;
                case RightSideRandomRotationDirectionMovement:
                    _rightSideRandomRotationDirectionMovement.GetComponent<WordSignSetter>().Set(sprite);
                    _rightSideRandomRotationDirectionMovement.GetComponent<WordRandomRespawn>().SetNewPosition();
                    _rightSideRandomRotationDirectionMovement.ChangeMoveDirection();
                    _rightSideRandomRotationDirectionMovement.SetMove();
                    break;
            }
        }

        public void HideAll()
        {
            _straightLineWordMovement.SetStop();
            _diagonalWordMovement.SetStop();
            _fullRandomDirectionMovement.SetStop();
            _leftSideDirectionMovement.SetStop();
            _leftSideRandomAngleDirectionMovement.SetStop();
            _randomSideDirectionMovement.SetStop();
            _rightSideDirectionMovement.SetStop();
            _rightSideRandomRotationDirectionMovement.SetStop();
        }
    }
}