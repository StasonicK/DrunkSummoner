using UnityEngine;

namespace UI.Screens.GamePlay.Economy
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int _initialMoneyCount;
        [SerializeField] private MoneyCounter _moneyCounter;

        private static Money _instance;

        private int _moneyCount;
        private int _result;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _moneyCount = _initialMoneyCount;
            _moneyCounter.SetMoney(_moneyCount);
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

        public void AddMoney(int value)
        {
            _moneyCount += value;
            _moneyCounter.SetMoney(_moneyCount);
        }

        public bool TryReduceMoney(int value)
        {
            _result = _moneyCount - value;

            if (_result >= 0)
            {
                _moneyCount -= value;
                _moneyCounter.SetMoney(_moneyCount);
                return true;
            }

            return false;
        }
    }
}