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

        private const float DELIMETER_VALUE = 100;

        private static DrinkButton _instance;

        private Button _button;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _button = GetComponent<Button>();
            _button.onClick.AddListener(AddAlcoholLevel);
        }

        private void OnEnable() =>
            On();

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                AddAlcoholLevel();
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

        private void AddAlcoholLevel()
        {
            if (Money.Instance.TryReduceMoney(_addAlcoholLevelPrice))
                _alcoholLevel.TryAddAlcoholLevel(_addAlcoholLevelValue / DELIMETER_VALUE);
        }

        public void On() =>
            _button.enabled = true;

        public void Off() =>
            _button.enabled = false;
    }
}