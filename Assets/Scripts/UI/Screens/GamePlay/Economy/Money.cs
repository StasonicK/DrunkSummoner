using UnityEngine;

namespace UI.Screens.GamePlay.Economy
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int _initialMoneyCount;
        [SerializeField] private MoneyCounter _moneyCounter;

        private static Money _instance;

        private int _currentMoneyCount;
        private int _previousMoneyCount;
        private int _result;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _currentMoneyCount = _initialMoneyCount;
            _previousMoneyCount = _initialMoneyCount;
            _moneyCounter.SetMoney(_currentMoneyCount);
        }

        public static Money Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Money>();

                return _instance;
            }
        }

        public void Start() =>
            _previousMoneyCount = _currentMoneyCount;

        public void SetPreviousMoneyCount() =>
            _previousMoneyCount = _currentMoneyCount;

        public void Restart()
        {
            _currentMoneyCount = _previousMoneyCount;
            _moneyCounter.SetMoney(_currentMoneyCount);
        }

        public void AddMoney(int value)
        {
            _currentMoneyCount += value;
            _moneyCounter.SetMoney(_currentMoneyCount);
        }

        public bool TryReduceMoney(int value)
        {
            _result = _currentMoneyCount - value;

            if (_result >= 0)
            {
                _currentMoneyCount -= value;
                _moneyCounter.SetMoney(_currentMoneyCount);
                return true;
            }

            return false;
        }
    }
}