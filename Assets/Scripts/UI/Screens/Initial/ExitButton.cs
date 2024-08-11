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

            if (Application.platform == RuntimePlatform.WebGLPlayer || Application.isEditor)
                gameObject.SetActive(false);
        }

        private void Exit() =>
            Application.Quit();
    }
}