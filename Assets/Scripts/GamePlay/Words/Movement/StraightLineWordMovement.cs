using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Words.Movement
{
    public class StraightLineWordMovement : WordMovement
    {
        [SerializeField] private float _movementMultiplier;

        protected override void AwakeChild()
        {
            _isVertical = Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE);
            _isPositive = Random.Range(Constants.ZERO_INT, MAX_EXCLUSIVE_VALUE);

            if (IsVertical(_isVertical))
                _xDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
            else
                _yDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;

            MoveDirection = new Vector3(_xDirection, _yDirection, Constants.ZERO_INT);
        }

        protected override void Move() => 
            transform.Translate(MoveDirection.normalized * _movementMultiplier * Time.deltaTime);
    }
}