using System;
using UnityEngine;

namespace Gameplay
{
    public class Cell : MonoBehaviour, IClickable
    {
        public event Action OnClick;
        public event Action OnChanged;

        public CellType StartCellType;
        
        //Active strategy on start
        private ICellStrategy _activeStrategy;
        public ICellStrategy ActiveStrategy { get => _activeStrategy; }

        private void OnEnable()
        { 
            //Set active strategy on start gaming
            SetActiveStrategy(CellType.Empty);

            //Onclick event subscription
            OnClick += _activeStrategy.Execute;
        }

        private void OnDisable()
        {
            //Unsubscribing from an event
            OnClick -= _activeStrategy.Execute;
        }

        /// <summary>
        /// Method for changing active strategy
        /// </summary>
        /// <param name="cellType">Current strategy</param>
        public void SetActiveStrategy(CellType cellType)
        {
            if(_activeStrategy!=null)
                OnClick -= _activeStrategy.Execute;
            _activeStrategy = BehaviourDictionary.Strategies[cellType];
            OnClick += _activeStrategy.Execute;
            OnChanged?.Invoke();
        }

        public void Click() => OnClick?.Invoke();
    }
}

