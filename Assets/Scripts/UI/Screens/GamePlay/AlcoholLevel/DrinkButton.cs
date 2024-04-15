using System.Collections;
using UI.Screens.GamePlay.Economy;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay.AlcoholLevel
{
    public class DrinkButton : MonoBehaviour
    {
        [SerializeField] private AlcoholLevel _alcoholLevel;
        [SerializeField] private float _addAlcoholLevelValue;
        [SerializeField] private int _addAlcoholLevelPrice;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _drinkDelayMilliseconds = 60f;
        [SerializeField] private float _fullDrinkDelayMilliseconds = 120f;

        private const float DELIMETER_VALUE = 100;
        private const string DRINKING_ANIMATION_STATE = "DrinkingAnimation";
        private const float ZERO_TIME = 0f;
        private const float MILLISECONDS_PER_SECOND = 60f;

        private static DrinkButton _instance;

        private Button _button;
        private float _currentTime = ZERO_TIME;
        private bool _drinkingProgress;
        private float _drinkDelayPerSecond;
        private float _fullDrinkDelayPerSecond;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _button = GetComponent<Button>();
            _button.onClick.AddListener(TryAddAlcoholLevel);
            _drinkDelayPerSecond = _drinkDelayMilliseconds / MILLISECONDS_PER_SECOND;
            _fullDrinkDelayPerSecond = _fullDrinkDelayMilliseconds / MILLISECONDS_PER_SECOND;
        }

        private void OnEnable() =>
            On();

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                TryAddAlcoholLevel();
        }

        public static DrinkButton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<DrinkButton>();

                return _instance;
            }
        }

        private void TryAddAlcoholLevel()
        {
            if (_drinkingProgress)
                return;

            if (Money.Instance.TryReduceMoney(_addAlcoholLevelPrice))
            {
                StartCoroutine(CoroutineDrink());
            }
        }

        private IEnumerator CoroutineDrink()
        {
            _drinkingProgress = true;
            _animator.Play(DRINKING_ANIMATION_STATE);

            while (_currentTime <= _drinkDelayPerSecond)
            {
                _currentTime += Time.deltaTime;
                yield return null;
            }

            _alcoholLevel.TryAddAlcoholLevel(_addAlcoholLevelValue / DELIMETER_VALUE);

            while (_currentTime <= _fullDrinkDelayPerSecond)
            {
                _currentTime += Time.deltaTime;
                yield return null;
            }

            _currentTime = ZERO_TIME;
            _drinkingProgress = false;
        }

        public void On() =>
            _button.enabled = true;

        public void Off() =>
            _button.enabled = false;
    }
}