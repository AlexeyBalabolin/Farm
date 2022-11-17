using Infrastructure.Factory;
using Infrastructure.Services;
using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class Plant : MonoBehaviour, IPointerEnter
    {
        public event Action OnClick;

        public InstrumentType InstrumentType { get; private set; }
        public int Score { get; private set; }

        protected IScoreService _scoreService;
        protected IGameFactory _gameFactory;

        public void Construct(PlantData plantData)
        {
            InstrumentType = plantData.InstrumentType;
            Score = plantData.Score;
            _scoreService = ServiceLocator.Container.GetService<IScoreService>();
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
        }

        public void PointerEnter(InstrumentType instrumentType)
        {
            if (instrumentType == InstrumentType)
                ActivatePlant();
        }

        protected abstract void ActivatePlant();
    }
}

