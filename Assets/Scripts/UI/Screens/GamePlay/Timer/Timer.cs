using System.Collections;
using Infrastructure;
using UnityEngine;

namespace UI.Screens.GamePlay.Timer
{
    public class Timer : MonoBehaviour
    {
        private const float FAIL_THRESHOLD = 0f;

        private static Timer _instance;

        private TimeLimitBar _timeLimitBar;
        private float _maxTime;
        private float _currentTime;
        private Coroutine _startCoroutine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _timeLimitBar = GetComponent<TimeLimitBar>();
        }

        public static Timer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Timer>();

                return _instance;
            }
        }

        public void Construct(float maxTime)
        {
            _maxTime = maxTime;
            _currentTime = maxTime;
        }

        public void Start()
        {
            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);

            _startCoroutine = StartCoroutine(CoroutineUpdateTimeLimitBar());
        }

        public void Stop()
        {
            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);
        }

        public void Reset()
        {
            if (_startCoroutine != null)
                StopCoroutine(_startCoroutine);

            _currentTime = _maxTime;
            _timeLimitBar.SetValue(_currentTime, _maxTime);
        }

        private IEnumerator CoroutineUpdateTimeLimitBar()
        {
            while (_currentTime > FAIL_THRESHOLD)
            {
                UpdateTimeLimitBar();
                _currentTime -= Time.deltaTime;
                yield return null;
            }

            Stop();
            GameStateManager.Instance.ShowFailWindow();
        }

        private void UpdateTimeLimitBar() =>
            _timeLimitBar.SetValue(_currentTime, _maxTime);
    }
}