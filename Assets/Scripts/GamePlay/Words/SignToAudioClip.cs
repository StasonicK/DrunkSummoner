using UnityEngine;

namespace GamePlay.Words
{
    [SerializeField]
    public class SignToAudioClip
    {
        public Sprite Sign;
        public AudioClip Audio;

        public SignToAudioClip(Sprite sign, AudioClip audio)
        {
            Sign = sign;
            Audio = audio;
        }
    }
}