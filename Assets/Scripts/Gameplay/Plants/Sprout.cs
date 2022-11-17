using Audio;
using FX;
using Infrastructure.Factory;
using Infrastructure.Services;
using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Sprout : MonoBehaviour, IBar
    {
        private float _currentTime, _maxTime;
        private IGameFactory _gameFactory;

        public float CurrentValue { get => _currentTime; set => _currentTime = value; }
        public float MaxValue { get => _maxTime; set => _maxTime = value; }

        public event Action OnValueChanged;

        private IScoreService _scoreService;

        public void StartGrown(float grownTime, PlantData plantData, IGameFactory gameFactory)
        {
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            _gameFactory.FxPooler.GetComponent<FxPooler>().PlayEffectByType(EffectType.CreateSprout, transform.position);
            _scoreService = ServiceLocator.Container.GetService<IScoreService>();
            StartCoroutine(Growing(grownTime, plantData, gameFactory));
        }

        private IEnumerator Growing(float grownTime, PlantData plantData, IGameFactory gameFactory)
        {
            CurrentValue = 0;
            MaxValue = grownTime;
            _gameFactory.Audio.GetComponent<AudioPlayer>().PlayAudioType(Audio.AudioType.GrownPlant);
            while (CurrentValue <= MaxValue)
            {
                yield return new WaitForSeconds(1);
                CurrentValue++;
                OnValueChanged?.Invoke();
            }
            Plant plant = gameFactory.CreateGameobjectAtPoint(plantData.PlantPrefab, transform.parent).GetComponent<Plant>();
            plant.Construct(plantData);
            _scoreService.AddScore(plantData.Score);
            gameFactory.DestroyObject(gameObject);
        }
    }
}

