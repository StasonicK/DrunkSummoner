using System;
using DG.Tweening;
using GamePlay.Words.Movement;
using UnityEngine;

namespace GamePlay.Words
{
    public class VisibilitySetter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
        [SerializeField] private SpriteRenderer _signSpriteRenderer;
        [SerializeField] private float _fadeOutDuration = 1f;
        [SerializeField] private float _fadeInDuration = 1f;

        private WordMovement _wordMovement;
        private Coroutine _coroutine;

        public event Action FadedOut;
        public event Action FadedIn;

        private void Start()
        {
            _wordMovement = GetComponent<WordMovement>();
        }

        public void FadeOut()
        {
            _backgroundSpriteRenderer.DOFade(0, _fadeOutDuration);
            _signSpriteRenderer.DOFade(0, _fadeOutDuration).OnComplete(() =>
                FadedOut?.Invoke());
            // _backgroundSpriteRenderer.DOFade(0, _fadeOutDuration);
            // _signSpriteRenderer.DOFade(0, _fadeOutDuration).OnComplete(() =>
            //     FadedOut?.Invoke());
            // _backgroundSpriteRenderer.DOFade(0, _fadeOutDuration);
            // _signSpriteRenderer.DOFade(0, _fadeOutDuration).OnComplete(() =>
            //     _wordMovement.SetStop());
        }

        public void FadeIn()
        {
            _backgroundSpriteRenderer.DOFade(0, 0);
            _signSpriteRenderer.DOFade(0, 0);
            FadedIn?.Invoke();
            // GetWordMovementComponent();
            // _wordMovement.SetMove();
            _backgroundSpriteRenderer.DOFade(1, _fadeInDuration);
            _signSpriteRenderer.DOFade(1, _fadeInDuration);
        }


        private void GetWordMovementComponent()
        {
            if (_wordMovement == null)
                _wordMovement = GetComponent<WordMovement>();
        }
    }
}