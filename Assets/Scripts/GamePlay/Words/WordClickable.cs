using Infrastructure;
using UnityEngine;

namespace GamePlay.Words
{
    public class WordClickable : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GameStateManager.Instance.WordCatched();
        }
    }
}