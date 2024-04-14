using UnityEngine;

namespace GamePlay.Words
{
    public class VisibilityChecker : MonoBehaviour
    {
        [SerializeField] private float _lowerEdge = -0.1f;
        [SerializeField] private double _upperEdge = 1.1;

        private Camera _mainCamera;
        private Vector3 _viewportPosition;
        private Vector3 _cameraViewportToWorldPoint;
        private Vector3 _newPosition;

        private void Start() =>
            _mainCamera = Camera.main;

        private void Update()
        {
            _viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
            MoveToOppositeScreenEdge();
        }

        private void MoveToOppositeScreenEdge()
        {
            if (_viewportPosition.x < _lowerEdge || _viewportPosition.x > _upperEdge ||
                _viewportPosition.y < _lowerEdge ||
                _viewportPosition.y > _upperEdge)
            {
                _newPosition = transform.localPosition;

                switch (_viewportPosition.x)
                {
                    case < 0:
                    case > 1:
                        _newPosition.x = -_newPosition.x;
                        break;
                    default:
                    {
                        switch (_viewportPosition.y)
                        {
                            case < 0:
                            case > 1:
                                _newPosition.y = -_newPosition.y;
                                break;
                        }

                        break;
                    }
                }

                transform.localPosition = _newPosition;
            }
        }
    }
}