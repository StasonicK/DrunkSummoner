using UnityEngine;

namespace GamePlay.Words
{
    public class WordClipSetter : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;

        public AudioClip AudioClip => _audioClip;

        public void Set(AudioClip audioClip) =>
            _audioClip = audioClip;
    }
}