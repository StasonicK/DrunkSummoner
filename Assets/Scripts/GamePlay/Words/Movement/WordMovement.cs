using UnityEngine;

namespace GamePlay.Words.Movement
{
    public abstract class WordMovement : MonoBehaviour
    {
        protected const int MIN_INCLUSIVE_VALUE = 0;
        protected const int MAX_EXCLUSIVE_VALUE = 2;
        protected const int POSITIVE_DIRECTION = 1;
        protected const int NEGATIVE_DIRECTION = -1;

        protected int _isVertical;
        protected int _isPositive;
        protected int _xDirection;
        protected int _yDirection;
        private bool _move;
        private Vector3 _initialPosition;

        private void Awake()
        {
            _initialPosition = transform.position;
            ChildAwake();
        }

        private void OnEnable()
        {
            transform.position = _initialPosition;
            _move = true;
        }

        private void OnDisable() =>
            _move = false;

        private void Update()
        {
            if (_move)
                Move();
        }

        protected virtual void ChildAwake()
        {
        }

        protected static bool IsVertical(int isVertical) =>
            isVertical != MIN_INCLUSIVE_VALUE;

        protected static bool IsPositive(int isPositive) =>
            isPositive != MIN_INCLUSIVE_VALUE;

        protected abstract void Move();
    }
}