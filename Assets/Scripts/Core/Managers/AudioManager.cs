using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _gameBGMSound;
        [SerializeField] private AudioClip _buttonClickSound;
        [SerializeField] private AudioClip _screenClickSound;
        [SerializeField] private AudioSource _mainMusicAudioSource, _ambienceAudioSource;

        void Start()
        {
            UIManager.Instance.OnScreenClicked += PlayScreenClickSound;
            _mainMusicAudioSource.clip = _gameBGMSound;
            _mainMusicAudioSource.Play();
        }

        void OnDisable()
        {
            UIManager.Instance.OnScreenClicked -= PlayScreenClickSound;
        }

        private void PlayScreenClickSound()
        {
            _ambienceAudioSource.clip = _screenClickSound;
            _ambienceAudioSource.Play();
        }

        public void UIEVENT_PlayButtonClickSound()
        {
            _ambienceAudioSource.clip = _buttonClickSound;
            _ambienceAudioSource.Play();
        }
    }
}
