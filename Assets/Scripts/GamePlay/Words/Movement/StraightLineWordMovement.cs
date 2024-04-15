using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Words.Movement
{
    public class StraightLineWordMovement : WordMovement
    {
        [SerializeField] private float _movementMultiplier;

        protected override void ChildAwake()
        {
            _isVertical = Random.Range(MIN_INCLUSIVE_VALUE, MAX_EXCLUSIVE_VALUE);
            _isPositive = Random.Range(MIN_INCLUSIVE_VALUE, MAX_EXCLUSIVE_VALUE);

            if (IsVertical(_isVertical))
                _xDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
            else
                _yDirection = IsPositive(_isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
        }

        protected override void Move()
        {
            transform.Translate(new Vector3(_xDirection * _movementMultiplier * Time.deltaTime,
                _yDirection * _movementMultiplier * Time.deltaTime, MIN_INCLUSIVE_VALUE));
        }
    }
}