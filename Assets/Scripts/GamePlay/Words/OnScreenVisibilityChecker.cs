using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Words
{
    public class OnScreenVisibilityChecker : MonoBehaviour
    {
        // [SerializeField] private float _startAppearEdge = -0.1f;
        // [SerializeField] private float _endAppearEdge = 1.1f;
        [SerializeField] private float _startDisappearEdge = -0.15f;
        [SerializeField] private float _endDisappearEdge = 1.15f;
        [SerializeField] private float _disappearToAppearDifferance = 0.05f;

        private const int AFTER_MOVE_TO_OPPOSITE_SCREEN_EDGE_DELAY = 500;

        private Camera _mainCamera;
        private float _newXPosition;
        private float _newYPosition;
        private Vector3 _viewportPosition = Vector3.zero;
        private Vector3 _newPosition = Vector3.zero;
        private float _endAppearEdge;
        private float _startAppearEdge;

        private void Start() =>
            _mainCamera = Camera.main;

        private void Update()
        {
            _viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
            CheckScreenEdge();
        }

        private async void CheckScreenEdge()
        {
            if (_viewportPosition.x < _startDisappearEdge || _viewportPosition.x > _endDisappearEdge ||
                _viewportPosition.y < _startDisappearEdge ||
                _viewportPosition.y > _endDisappearEdge)
            {
                MoveToOppositeSide();
                await UniTask.Yield();
                await UniTask.Delay(AFTER_MOVE_TO_OPPOSITE_SCREEN_EDGE_DELAY);
            }
        }

        private void MoveToOppositeSide()
        {
            // Debug.Log("MoveToOppositeSide start");
            _newPosition = transform.localPosition;

            if ((_viewportPosition.x < _startDisappearEdge && _viewportPosition.y < _startDisappearEdge) ||
                (_viewportPosition.x > _endDisappearEdge && _viewportPosition.y < _startDisappearEdge) ||
                (_viewportPosition.x < _startDisappearEdge && _viewportPosition.y > _endDisappearEdge) ||
                (_viewportPosition.x > _endDisappearEdge && _viewportPosition.y > _endDisappearEdge))
            {
                _newPosition.x *= -.95f;
                _newPosition.y *= -.95f;
            }
            else if (_viewportPosition.x < _startDisappearEdge || _viewportPosition.x > _endDisappearEdge)
            {
                _newPosition.x *= -.95f;
            }
            else if (_viewportPosition.y < _startDisappearEdge || _viewportPosition.y > _endDisappearEdge)
            {
                _newPosition.y *= -.95f;
            }

            transform.localPosition = _newPosition;
        }
    }
}