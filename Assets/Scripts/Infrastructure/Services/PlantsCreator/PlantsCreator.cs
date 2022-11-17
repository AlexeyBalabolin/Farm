using System;
using Gameplay;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class PlantsCreator:IService
    {
        public event Action OnActiveCellSelected;

        private Cell _activeCell;

        public AllPlants PlantsList { get; private set; }
        public Cell ActiveCell
        {
            get => _activeCell;
            set
            {
                _activeCell = value;
                OnActiveCellSelected?.Invoke();
            }
        }

        public PlantsCreator(AllPlants plantsList) => PlantsList = plantsList;
    }
}

