using UnityEngine;

namespace GamePlay.Words
{
    public class WordClickable : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log($"OnMouseDown on: {gameObject.name}");
        }
    }
}