using GamePlay.SummoningSpells;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _music;
        [SerializeField] private AudioClip _winSoundFx;
        [SerializeField] private AudioClip _failSoundFx;
        [SerializeField] private AudioClip _drinkBeerSoundFx;
        [SerializeField] private AudioClip _potatoBagCreatedSoundFx;
        [SerializeField] private AudioClip _chickenCreatedFx;
        [SerializeField] private AudioClip _shovelCreatedSoundFx;
        [SerializeField] private AudioClip _closeWindowSoundFx;
        [SerializeField] private AudioClip _openWindowSoundFx;

        [SerializeField] private AudioSource _musicAudio;
        [SerializeField] private AudioSource _uiSoundAudio;
        [SerializeField] private AudioSource _environmentSoundAudio;
        [SerializeField] private AudioSource _wordSoundAudio;
        [SerializeField] private AudioSource _summonerSoundAudio;
        [SerializeField] private AudioSource _creationSoundSoundAudio;

        private AudioClip _currentWordAudioClip;
        private AudioClip _currentCreatedObjectAudioClip;

        private const float MAX_VOLUME = 1.0f;

        private static AudioManager _instance;
        private float _volume;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Start()
        {
            _musicAudio.volume = MAX_VOLUME;
            _uiSoundAudio.volume = MAX_VOLUME;
            _environmentSoundAudio.volume = MAX_VOLUME;
            _wordSoundAudio.volume = MAX_VOLUME;
            _summonerSoundAudio.volume = MAX_VOLUME;
            _creationSoundSoundAudio.volume = MAX_VOLUME;
            _volume = MAX_VOLUME;
            PlayAudio(AudioTrack.Music);
        }

        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AudioManager>();

                return _instance;
            }
        }

        public void SetWordAudioClip(AudioClip audioClip) =>
            _currentWordAudioClip = audioClip;

        public void SetCreatedObjectAudioClip(SummoningSpellId summoningSpellId)
        {
            switch (summoningSpellId)
            {
                case SummoningSpellId.PotatoBag:
                    _currentCreatedObjectAudioClip = _potatoBagCreatedSoundFx;
                    break;
                case SummoningSpellId.Chicken:
                    _currentCreatedObjectAudioClip = _chickenCreatedFx;
                    break;
                case SummoningSpellId.Shovel:
                    _currentCreatedObjectAudioClip = _shovelCreatedSoundFx;
                    break;
            }
        }

        public void PlayWord()
        {
            if (_currentWordAudioClip != null)
                AudioInnerManager(_currentWordAudioClip, _volume, AudioLayer.WordSound);
        }

        public void PlayCreatedObject()
        {
            if (_currentCreatedObjectAudioClip != null)
                AudioInnerManager(_currentCreatedObjectAudioClip, _volume, AudioLayer.WordSound);
        }

        public void PlayAudio(AudioTrack track)
        {
            switch (track)
            {
                case AudioTrack.Music:
                    AudioInnerManager(_music, _volume, AudioLayer.Music);
                    break;
                case AudioTrack.WinSoundFx:
                    AudioInnerManager(_winSoundFx, _volume, AudioLayer.EnvironmentSound);
                    break;
                case AudioTrack.FailSoundFx:
                    AudioInnerManager(_failSoundFx, _volume, AudioLayer.EnvironmentSound);
                    break;
                case AudioTrack.DrinkBeerSoundFx:
                    AudioInnerManager(_drinkBeerSoundFx, _volume, AudioLayer.SummonerSound);
                    break;
                case AudioTrack.PotatoBagCreatedSoundFx:
                    AudioInnerManager(_potatoBagCreatedSoundFx, _volume, AudioLayer.CreationSound);
                    break;
                case AudioTrack.ChickenCreatedSoundFx:
                    AudioInnerManager(_chickenCreatedFx, _volume, AudioLayer.CreationSound);
                    break;
                case AudioTrack.ShovelCreatedSoundFx:
                    AudioInnerManager(_shovelCreatedSoundFx, _volume, AudioLayer.CreationSound);
                    break;
                case AudioTrack.CloseWindowSoundFx:
                    AudioInnerManager(_closeWindowSoundFx, _volume, AudioLayer.UISound);
                    break;
                case AudioTrack.OpenWindowSoundFx:
                    AudioInnerManager(_openWindowSoundFx, _volume, AudioLayer.UISound);
                    break;
            }
        }

        private void AudioInnerManager(AudioClip soundToPlay, float audioLevel, AudioLayer layer)
        {
            switch (layer)
            {
                case AudioLayer.Music:
                    _musicAudio.clip = soundToPlay;
                    _musicAudio.Play();
                    _musicAudio.loop = true;
                    _musicAudio.volume = audioLevel;
                    break;
                case AudioLayer.WordSound:
                    _wordSoundAudio.clip = soundToPlay;
                    _wordSoundAudio.Play();
                    _wordSoundAudio.loop = false;
                    _wordSoundAudio.volume = audioLevel;
                    break;
                case AudioLayer.UISound:
                    _uiSoundAudio.clip = soundToPlay;
                    _uiSoundAudio.Play();
                    _uiSoundAudio.loop = false;
                    _uiSoundAudio.volume = audioLevel;
                    break;
                case AudioLayer.EnvironmentSound:
                    _environmentSoundAudio.clip = soundToPlay;
                    _environmentSoundAudio.Play();
                    _environmentSoundAudio.loop = false;
                    _environmentSoundAudio.volume = audioLevel;
                    break;
                case AudioLayer.SummonerSound:
                    _summonerSoundAudio.clip = soundToPlay;
                    _summonerSoundAudio.Play();
                    _summonerSoundAudio.loop = false;
                    _summonerSoundAudio.volume = audioLevel;
                    break;
                case AudioLayer.CreationSound:
                    _creationSoundSoundAudio.clip = soundToPlay;
                    _creationSoundSoundAudio.Play();
                    _creationSoundSoundAudio.loop = false;
                    _creationSoundSoundAudio.volume = audioLevel;
                    break;
                default:
                    Debug.LogWarning("Audio Layer Does Not Exist");
                    break;
            }
        }
    }
}