using UnityEngine;

namespace GamePlay
{
    public class WordsHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _word;

        public void Show()
        {
            _word.SetActive(true);
        }

        public void Hide()
        {
            _word.SetActive(false);
        }

        public void HideAll()
        {
            _word.SetActive(false);
        }
    }
}