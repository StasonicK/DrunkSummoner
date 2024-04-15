using UnityEngine;

namespace GamePlay.Words
{
    public class WordSignSetter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _wordSignSpriteRenderer;

        public void Set(Sprite sprite) =>
            _wordSignSpriteRenderer.sprite = sprite;
    }
}