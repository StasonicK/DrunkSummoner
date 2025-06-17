using System;
using Infrastructure;
using UnityEngine;

namespace UI.Screens.GamePlay.Timer
{
    public class DifficultyController : MonoBehaviour
    {
        [SerializeField] private GameObject _timerGameObject;

        private void OnEnable()
        {
            if(GameStateManager.Instance.IsNormalDifficulty)
            {
                _timerGameObject.SetActive(false);
            }
            else
            {
                _timerGameObject.SetActive(true);
            }
        }
    }
}