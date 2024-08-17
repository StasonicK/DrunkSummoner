using DG.Tweening;
using UnityEngine;

namespace UI.Screens.GamePlay.AlcoholLevel
{
    public class AlcoholLevelDroppedZeroAnimator : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _rotateAngle = 30f;
        [SerializeField] private float _duration = 1f;

        private static AlcoholLevelDroppedZeroAnimator _instance;

        private Tween _rotationTween;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _targetTransform.gameObject.SetActive(false);
        }

        public static AlcoholLevelDroppedZeroAnimator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AlcoholLevelDroppedZeroAnimator>();

                return _instance;
            }
        }

        public void StartRotation()
        {
            _targetTransform.gameObject.SetActive(true);

            if (_rotationTween != null && _rotationTween.IsActive())
                _rotationTween.Kill();

            _rotationTween = _targetTransform.DORotate(new Vector3(0, 0, _rotateAngle), _duration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopRotation()
        {
            if (_rotationTween != null && _rotationTween.IsActive())
            {
                _rotationTween.Kill();
                _targetTransform.rotation = Quaternion.identity;
            }

            _targetTransform.gameObject.SetActive(false);
        }
    }
}