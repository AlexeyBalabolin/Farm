using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class Plant : MonoBehaviour, IClickable
    {
        public event Action OnClick;

        public string Name { get; private set; }
        public string Description { get; private set; }
        public float GrowthTime { get; private set; }
        public Sprite PlantSprite { get; private set; }
        public int Score { get; private set; }

        public void Construct(PlantData plantData)
        {
            Name = plantData.Name;
            Description = plantData.Description;
            GrowthTime = plantData.GrowthTime;
            PlantSprite = plantData.PlantSprite;
            Score = plantData.Score;
        }
        public void Click() => OnClick?.Invoke();
    }

    public class Grass : Plant
    {

    }
}

