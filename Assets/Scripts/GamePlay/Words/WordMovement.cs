using UnityEngine;

namespace GamePlay.Words
{
    public abstract class WordMovement : MonoBehaviour
    {
        private bool _move;

        private void OnEnable()
        {
            _move = true;
        }

        private void OnDisable() =>
            _move = false;

        private void Update()
        {
            if (_move)
                Move();
        }

        protected abstract void Move();
    }
}