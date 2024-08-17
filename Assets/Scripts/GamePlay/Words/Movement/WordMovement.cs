using UnityEngine;

namespace GamePlay.Words.Movement
{
    public abstract class WordMovement : MonoBehaviour
    {
        protected const int MAX_EXCLUSIVE_VALUE = 2;
        protected const int POSITIVE_DIRECTION = 1;
        protected const int NEGATIVE_DIRECTION = -1;

        protected int _isVertical;
        protected int _isPositive;
        protected int _xDirection;
        protected int _yDirection;
        private bool _move;
        protected Vector3 MoveDirection;

        public VisibilitySetter VisibilitySetter { get; private set; }

        private void Awake()
        {
            VisibilitySetter = GetComponent<VisibilitySetter>();
            VisibilitySetter.FadedOut += SetStop;
            VisibilitySetter.FadedIn += SetMove;
            AwakeChild();
        }

        private void Update()
        {
            if (_move)
            {
                UpdateChild();
                Move();
            }
        }

        protected virtual void AwakeChild()
        {
        }

        protected virtual void UpdateChild()
        {
        }

        public void SetMove()
        {
            // _visibilitySetter.FadeIn();
            gameObject.SetActive(true);
            _move = true;
        }

        public void SetStop()
        {
            gameObject.SetActive(false);
            _move = false;
        }

        protected bool IsVertical(int isVertical) =>
            isVertical != Constants.ZERO_INIT;

        protected bool IsPositive(int isPositive) =>
            isPositive != Constants.ZERO_INIT;

        protected abstract void Move();
    }
}