using UnityEngine;

namespace UI.Screens.GamePlay.Progress
{
    public class WordItem : MonoBehaviour
    {
        [SerializeField] private GameObject _empty;
        [SerializeField] private GameObject _catched;
        [SerializeField] private Animator _animator;

        public bool IsCatched { private set; get; }

        private void Awake() =>
            SetEmpty();

        public void SetEmpty()
        {
            IsCatched = false;
            _empty.SetActive(true);
            _catched.SetActive(false);
        }

        public void SetCatched()
        {
            _catched.SetActive(true);
            _empty.SetActive(false);
            IsCatched = true;
            // _animator.Play(Constants.AnimationLanternShow);
        }
    }
}