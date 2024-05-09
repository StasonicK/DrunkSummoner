using System.Collections;
using Infrastructure;
using UnityEngine;

namespace UI.Screens.GamePlay.AlcoholLevel
{
    public class AlcoholLevel : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1f)] private float _speedMultiplier;

        private const float FAIL_THRESHOLD = 0f;

        private static AlcoholLevel _instance;

        private AlcoholLevelBar _alcoholLevelBar;
        private float _maxLevel;
        private float _previousLevel;
        private float _currentLevel;
        private Coroutine _startCoroutine;
        private float _result;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _alcoholLevelBar = GetComponent<AlcoholLevelBar>();
            SetLevelsToMaxValue();
        }

        public static AlcoholLevel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AlcoholLevel>();

                return _instance;
            }
        }

        public void Start()
        {
            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);

            SetLevelsToMaxValue();
            _startCoroutine = StartCoroutine(CoroutineUpdateTimeLimitBar());
        }

        private void SetLevelsToMaxValue()
        {
            _maxLevel = _alcoholLevelBar.MaxSliderValue;
            _currentLevel = _maxLevel;
            _previousLevel = _maxLevel;
            UpdateTimeLimitBar();
        }

        public void SetPreviousLevel() =>
            _previousLevel = _currentLevel;

        public void Stop()
        {
            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);
        }

        public void Restart()
        {
            _currentLevel = _previousLevel;

            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);

            _startCoroutine = StartCoroutine(CoroutineUpdateTimeLimitBar());
        }

        public void TryAddAlcoholLevel(float value)
        {
            _result = _currentLevel + value;

            if (_result >= _maxLevel)
                _currentLevel = _maxLevel;
            else
                _currentLevel += value;
        }

        private IEnumerator CoroutineUpdateTimeLimitBar()
        {
            while (_currentLevel > FAIL_THRESHOLD)
            {
                _currentLevel -= Time.deltaTime * _speedMultiplier;
                UpdateTimeLimitBar();
                yield return null;
            }

            GameStateManager.Instance.ShowFailWindow();
        }

        private void UpdateTimeLimitBar() =>
            _alcoholLevelBar.SetValue(_currentLevel, _maxLevel);
    }
}