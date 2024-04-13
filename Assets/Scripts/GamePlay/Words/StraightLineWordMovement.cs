using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Words
{
    public class StraightLineWordMovement : WordMovement
    {
        [SerializeField] private float _movementMultiplier;

        private const int MIN_INCLUSIVE_VALUE = 0;
        private const int MAX_EXCLUSIVE_VALUE = 2;
        private const int POSITIVE_DIRECTION = 1;
        private const int NEGATIVE_DIRECTION = -1;

        private int _xDirection;
        private int _yDirection;

        private void Awake()
        {
            int isVertical = Random.Range(MIN_INCLUSIVE_VALUE, MAX_EXCLUSIVE_VALUE);
            int isPositive = Random.Range(MIN_INCLUSIVE_VALUE, MAX_EXCLUSIVE_VALUE);

            if (IsVertical(isVertical))
                _xDirection = IsPositive(isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
            else
                _yDirection = IsPositive(isPositive) ? POSITIVE_DIRECTION : NEGATIVE_DIRECTION;
        }

        private static bool IsVertical(int isVertical) =>
            isVertical != MIN_INCLUSIVE_VALUE;

        private static bool IsPositive(int isPositive) =>
            isPositive != MIN_INCLUSIVE_VALUE;

        protected override void Move()
        {
            transform.Translate(new Vector3(_xDirection * _movementMultiplier * Time.deltaTime,
                _yDirection * _movementMultiplier * Time.deltaTime, MIN_INCLUSIVE_VALUE));
        }
    }
}