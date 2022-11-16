using Infrastructure.Data;
using Infrastructure.Factory;
using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        public Action OnGameSaved;

        private const string ProgressKey = "Progress";
        private readonly IGameFactory _gameFactory;

        public PlayerProgress Progress { get; set; }

        public SaveLoadService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        //обновление прогресса
        public void SaveProgress()
        {
            foreach(var progressSaver in _gameFactory.ProgressSavers)
                progressSaver.SaveProgress(Progress);
            PlayerPrefs.SetString(key: ProgressKey, Progress.ToJson());
            OnGameSaved?.Invoke();
            PlayerPrefs.Save();
            Debug.Log(Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>() ?? new PlayerProgress();
    }
}
