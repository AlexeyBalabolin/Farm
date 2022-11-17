using Infrastructure.Factory;
using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Sprout : MonoBehaviour, IBar
    {
        private float _currentTime, _maxTime;

        public float CurrentValue { get => _currentTime; set => _currentTime = value; }
        public float MaxValue { get => _maxTime; set => _maxTime = value; }

        public event Action OnValueChanged;

        public void StartGrown(float grownTime, PlantData plantData, IGameFactory gameFactory) => StartCoroutine(Growing(grownTime, plantData, gameFactory));

        private IEnumerator Growing(float grownTime, PlantData plantData, IGameFactory gameFactory)
        {
            CurrentValue = 0;
            MaxValue = grownTime;
            while (CurrentValue <= MaxValue)
            {
                yield return new WaitForSeconds(1);
                CurrentValue++;
                OnValueChanged?.Invoke();
            }
            Plant plant = gameFactory.CreateGameobjectAtPoint(plantData.PlantPrefab, transform.parent).GetComponent<Plant>();
            plant.Construct(plantData);
            gameFactory.DestroyObject(gameObject);
        }
    }
}

