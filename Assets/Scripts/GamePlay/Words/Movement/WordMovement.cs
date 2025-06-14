using Infrastructure;
using UnityEngine;

namespace GamePlay.Words.Movement
{
    [RequireComponent(typeof(VisibilitySetter))]
    [RequireComponent(typeof(AudioChangeDirectionComponent))]
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
        private AudioChangeDirectionComponent _audioChangeDirectionComponent;
        private bool _isCommonMode;

        public VisibilitySetter VisibilitySetter { get; private set; }

        private void Awake()
        {
            VisibilitySetter = GetComponent<VisibilitySetter>();
            _audioChangeDirectionComponent = GetComponent<AudioChangeDirectionComponent>();

            AwakeChild();
            VisibilitySetter.FadedOut += SetStop;
            VisibilitySetter.FadedIn += SetMove;
        }

        private void OnDestroy()
        {
            VisibilitySetter.FadedOut -= SetStop;
            VisibilitySetter.FadedIn -= SetMove;
            _audioChangeDirectionComponent.OnChangeDirectionEvent -= TryChangeDirection;
        }

        private void OnEnable()
        {
            _isCommonMode = GameStateManager.Instance.IsCommonMode;

            if (!_isCommonMode)
                _audioChangeDirectionComponent.OnChangeDirectionEvent += TryChangeDirection;
        }

        private void OnDisable()
        {
            _audioChangeDirectionComponent.OnChangeDirectionEvent -= TryChangeDirection;
        }

        private void Update()
        {
            if (_move)
            {
                if (_isCommonMode)
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

        private void TryChangeDirection()
        {
            if (_move)
                ChangeMoveDirection();
        }

        protected bool IsVertical(int isVertical) =>
            isVertical != Constants.ZERO_INT;

        protected bool IsPositive(int isPositive) =>
            isPositive != Constants.ZERO_INT;

        protected abstract void Move();

        public virtual void ChangeMoveDirection()
        {
        }
    }
}