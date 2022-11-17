using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class Plant : MonoBehaviour, IPointerEnter
    {
        public event Action OnClick;

        public InstrumentType InstrumentType { get; private set; }
        public int Score { get; private set; }

        public void Construct(PlantData plantData)
        {
            InstrumentType = plantData.InstrumentType;
            Score = plantData.Score;
        }

        public void PointerEnter(InstrumentType instrumentType)
        {
            if (instrumentType == InstrumentType)
                ActivatePlant();
        }

        protected abstract void ActivatePlant();
    }
}

