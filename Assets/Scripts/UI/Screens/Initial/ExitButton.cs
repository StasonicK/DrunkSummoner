using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Initial
{
    public class ExitButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Exit);
        }

        private void Exit()
        {
            if (!Application.isEditor)
                Application.Quit();
        }
    }
}