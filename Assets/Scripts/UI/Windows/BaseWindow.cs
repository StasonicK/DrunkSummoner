using UnityEngine;

namespace UI.Windows
{
    public class BaseWindow : MonoBehaviour
    {
        public void Show() =>
            gameObject.SetActive(true);
        
        public void Hide() =>
            gameObject.SetActive(false);
    }
}