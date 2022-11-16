using Infrastructure.Factory;
using System;
using System.Collections;
using UI;
using UnityEngine;

public class Sprout : MonoBehaviour, IBar
{
    private float _currentTime, _maxTime;

    public float CurrentValue { get => _currentTime; set => _currentTime = value; }
    public float MaxValue { get => _maxTime; set => _maxTime = value; }

    public event Action OnValueChanged;

    public void StartGrown(float grownTime, GameObject plantPrefab, IGameFactory gameFactory) => StartCoroutine(Growing(grownTime, plantPrefab, gameFactory));

    private IEnumerator Growing(float grownTime, GameObject plantPrefab, IGameFactory gameFactory)
    {
        CurrentValue = 0;
        MaxValue = grownTime;
        while (CurrentValue<=MaxValue)
        {
            yield return new WaitForSeconds(1);
            CurrentValue++;
            OnValueChanged?.Invoke();
        }        
        gameFactory.CreateGameobjectAtPoint(plantPrefab, transform.parent);
        gameFactory.DestroyObject(gameObject);
    }
}
