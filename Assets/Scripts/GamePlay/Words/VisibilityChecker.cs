using UnityEngine;

namespace GamePlay.Words
{
    public class VisibilityChecker : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _viewportPosition;
        private Vector3 _cameraViewportToWorldPoint;
        private Vector3 _newPosition;

        private void Start() =>
            _mainCamera = Camera.main;

        private void Update()
        {
            _viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
            MoveToOpposizeScreenEdge();
        }

        private void MoveToOpposizeScreenEdge()
        {
            if (_viewportPosition.x < 0 || _viewportPosition.x > 1 || _viewportPosition.y < 0 ||
                _viewportPosition.y > 1)
            {
                _newPosition = transform.localPosition;

                switch (_viewportPosition.x)
                {
                    case < 0:
                        // _cameraViewportToWorldPoint = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));
                        _newPosition.x = -_newPosition.x;
                        break;
                    case > 1:
                        // _cameraViewportToWorldPoint = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
                        _newPosition.x = -_newPosition.x;
                        break;
                    default:
                    {
                        switch (_viewportPosition.y)
                        {
                            case < 0:
                                // _cameraViewportToWorldPoint = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
                                _newPosition.y = -_newPosition.y;
                                break;
                            case > 1:
                                // _cameraViewportToWorldPoint = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
                                _newPosition.y = -_newPosition.y;
                                break;
                        }

                        break;
                    }
                }

                transform.localPosition = _newPosition;
                // transform.localPosition = transform.InverseTransformPoint(new Vector3(_cameraViewportToWorldPoint.x,
                //     _cameraViewportToWorldPoint.y, _zDefaultPosition));
                // transform.position = new Vector3(_cameraViewportToWorldPoint.x, _cameraViewportToWorldPoint.y,
                //     _zDefaultPosition);
            }
        }
    }
}