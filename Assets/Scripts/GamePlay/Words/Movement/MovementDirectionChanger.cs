using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Words.Movement
{
    public class MovementDirectionChanger
    {
        private const int MIN_ANGLE = 30;

        private bool _isFullRandom;
        private bool _isSideChanger;
        private bool _isLeft;
        private bool _isRandomAngle;
        private float _angle;
        private Vector3 _oldDirection;

        public MovementDirectionChanger(bool isFullRandom, bool isSideChanger, bool isRandomAngle, bool isLeft)
        {
            _isFullRandom = isFullRandom;
            _isSideChanger = isSideChanger;
            _isRandomAngle = isRandomAngle;

            if (_isSideChanger)
            {
                if (Random.Range(0, 2) == 0)
                    _isLeft = true;
                else
                    _isLeft = false;
            }
            else
            {
                _isLeft = isLeft;
            }

            if (_isFullRandom)
                GetRandomSettings();
        }

        private void GetRandomSettings()
        {
            if (Random.Range(0, 2) == 0)
                _isSideChanger = true;
            else
                _isSideChanger = false;

            if (Random.Range(0, 2) == 0)
                _isLeft = true;
            else
                _isLeft = false;

            if (Random.Range(0, 2) == 0)
                _isRandomAngle = true;
            else
                _isRandomAngle = false;
        }

        public Vector3 ChangeDirection(Vector3 oldDirection)
        {
            _oldDirection = oldDirection;

            if (_isFullRandom)
                GetRandomSettings();

            if (_isRandomAngle)
                return GetRandomAngle();

            return Get90DegreesAngle();
        }

        private Vector3 GetRandomAngle()
        {
            _angle = Random.Range(MIN_ANGLE, Constants.MAX_ANGLE + 1);

            if (!_isLeft)
                _angle = -_angle;

            ChangeSide();
            return Quaternion.AngleAxis(_angle, Vector3.forward) * _oldDirection;
        }

        private void ChangeSide()
        {
            if (_isSideChanger)
                _isLeft = !_isLeft;
        }

        private Vector3 Get90DegreesAngle()
        {
            if (_isLeft)
                _angle = 90f;
            else
                _angle = -90f;

            ChangeSide();
            return Quaternion.AngleAxis(_angle, Vector3.forward) * _oldDirection;
        }
    }
}