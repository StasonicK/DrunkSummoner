using UnityEngine;

namespace GamePlay.Words.Movement
{
    public abstract class AnyDirectionWordMovement : WordMovement
    {
        [SerializeField] private float _movementMultiplier;
        [SerializeField] private float _singleDirectionTime;

        protected bool IsFullRandom;
        protected bool IsSideChanger;
        protected bool IsRandomAngle;
        protected bool IsLeft;

        private MovementDirectionChanger _movementDirectionChanger;
        private float _angle;
        private float _currentTime;
        private Vector3 _newDirection;

        protected override void UpdateChild()
        {
            if (_currentTime >= _singleDirectionTime)
            {
                _currentTime = Constants.ZERO_INT;
                ChangeMoveDirection();

                return;
            }

            _currentTime += Time.deltaTime;
        }

        public override void ChangeMoveDirection()
        {
            _newDirection = _movementDirectionChanger.ChangeDirection(MoveDirection);
            MoveDirection = new Vector3(_newDirection.x, _newDirection.y, Constants.ZERO_INT);
        }

        protected override void AwakeChild()
        {
            Initialize();
            _movementDirectionChanger =
                new MovementDirectionChanger(IsFullRandom, IsSideChanger, IsRandomAngle, IsLeft);
            _currentTime = Constants.ZERO_INT;

            _xDirection = IsPositive(Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE))
                ? POSITIVE_DIRECTION
                : NEGATIVE_DIRECTION;
            _yDirection = IsPositive(Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE))
                ? POSITIVE_DIRECTION
                : NEGATIVE_DIRECTION;

            MoveDirection = new Vector3(_xDirection, _yDirection, Constants.ZERO_INT);
        }

        protected abstract void Initialize();

        protected override void Move()
        {
            transform.Translate(MoveDirection.normalized * _movementMultiplier * Time.deltaTime);
        }
    }
}