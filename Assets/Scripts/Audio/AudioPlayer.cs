using Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _musicSource, _soundSource;

        [SerializeField]
        private List<AudioDictionary> _clips = new List<AudioDictionary>();

        private IScoreService _scoreService;

        private void OnEnable()
        {
            _scoreService = ServiceLocator.Container.GetService<IScoreService>();
            _scoreService.OnScoreChanged += () => PlayAudioType(AudioType.AddScore);
            DontDestroyOnLoad(this);
        }

        private void OnDisable() => _scoreService.OnScoreChanged -= () => PlayAudioType(AudioType.AddScore);

        public void PlayMusic() => _musicSource.Play();
        public void StopMusic() => _musicSource.Stop();

        public void PlayAudioType(AudioType type) => _soundSource.PlayOneShot(_clips.Where(clip => clip.AudioType == type).Select(clip => clip.Clip).First());
    }
}

