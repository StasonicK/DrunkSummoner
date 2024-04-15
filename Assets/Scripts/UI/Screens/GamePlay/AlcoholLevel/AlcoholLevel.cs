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

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _alcoholLevelBar = GetComponent<AlcoholLevelBar>();
            _maxLevel = _alcoholLevelBar.MaxSliderValue;
            _currentLevel = _maxLevel;
            _previousLevel = _maxLevel;
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

            _startCoroutine = StartCoroutine(CoroutineUpdateTimeLimitBar());
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

        public void AddAlcoholLevel(float value) =>
            _currentLevel += value;

        private IEnumerator CoroutineUpdateTimeLimitBar()
        {
            while (_currentLevel > FAIL_THRESHOLD)
            {
                UpdateTimeLimitBar();
                _currentLevel -= Time.deltaTime * _speedMultiplier;
                yield return null;
            }

            GameStateManager.Instance.ShowFailWindow();
        }

        private void UpdateTimeLimitBar() =>
            _alcoholLevelBar.SetValue(_currentLevel, _maxLevel);
    }
}