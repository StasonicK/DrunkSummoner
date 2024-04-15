using TMPro;
using UnityEngine;

namespace UI.Screens.GamePlay.Economy
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void SetMoney(int value) =>
            _moneyText.text = $"{value}";
    }
}