using Infrastructure;
using UnityEngine;

namespace UI.Screens.GamePlay.Timer
{
    public class TimerVisibilityController : MonoBehaviour
    {
        [SerializeField] private GameObject _timerGameObject;

        private void OnEnable()
        {
            _timerGameObject.SetActive(!GameStateManager.Instance.IsNormalDifficulty);
        }
    }
}