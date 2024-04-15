using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.GamePlay.AlcoholLevel
{
    public class DrinkButton : MonoBehaviour
    {
        [SerializeField] private AlcoholLevel _alcoholLevel;
        [SerializeField] private float _addAlcoholLevelValue;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(AddAlcoholLevel);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                AddAlcoholLevel();
        }

        private void AddAlcoholLevel() =>
            _alcoholLevel.AddAlcoholLevel(_addAlcoholLevelValue / 100);
    }
}