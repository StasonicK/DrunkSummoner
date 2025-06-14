using UnityEngine;

namespace GamePlay.Words.Movement
{
    public class DiagonalWordMovement : WordMovement
    {
        [SerializeField] private float _movementMultiplier;

        protected override void AwakeChild()
        {
            _isVertical = Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE);
            _isPositive = Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE);

            _xDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
            _yDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;

            MoveDirection = new Vector3(_xDirection, _yDirection, Constants.ZERO_INT);
        }

        protected override void Move() => 
            transform.Translate(MoveDirection.normalized * _movementMultiplier * Time.deltaTime);

        public override void ChangeMoveDirection()
        {
            
        }
    }
}