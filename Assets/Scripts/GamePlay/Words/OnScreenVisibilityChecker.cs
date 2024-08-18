using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Words
{
    public class OnScreenVisibilityChecker : MonoBehaviour
    {
        [SerializeField] private float _lowerEdge = -0.1f;
        [SerializeField] private float _upperEdge = 1.1f;

        private const int AFTER_MOVE_TO_OPPOSITE_SCREEN_EDGE_DELAY = 500;

        private Camera _mainCamera;
        private Vector3 _viewportPosition;
        private Vector3 _cameraViewportToWorldPoint;
        private Vector3 _newPosition;

        private void Start() =>
            _mainCamera = Camera.main;

        private void Update()
        {
            _viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
            CheckScreenEdge();
        }

        private async void CheckScreenEdge()
        {
            if (_viewportPosition.x < _lowerEdge || _viewportPosition.x > _upperEdge ||
                _viewportPosition.y < _lowerEdge ||
                _viewportPosition.y > _upperEdge)
            {
                MoveToOppositeSide();
                await UniTask.Yield(); // Ensure the position update is processed before the delay
                await UniTask.Delay(AFTER_MOVE_TO_OPPOSITE_SCREEN_EDGE_DELAY);
            }
        }

        private void MoveToOppositeSide()
        {
            Debug.Log("MoveToOppositeScreenEdge");
            _newPosition = transform.localPosition;

            if ((_viewportPosition.x < 0 && _viewportPosition.y < 0) ||
                (_viewportPosition.x > 1 && _viewportPosition.y < 0) ||
                (_viewportPosition.x < 0 && _viewportPosition.y > 1) ||
                (_viewportPosition.x > 1 && _viewportPosition.y > 1))
            {
                _newPosition.x = -_newPosition.x;
                _newPosition.y = -_newPosition.y;
            }
            else if (_viewportPosition.x < 0 || _viewportPosition.x > 1)
            {
                _newPosition.x = -_newPosition.x;
            }
            else if (_viewportPosition.y < 0 || _viewportPosition.y > 1)
            {
                _newPosition.y = -_newPosition.y;
            }

            transform.localPosition = _newPosition;
        }
    }
}