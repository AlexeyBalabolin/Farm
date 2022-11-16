using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Cell : MonoBehaviour, IClickable, IPointerExit
    {
        public UnityEvent OnClick,OnPointerExit;

        private PlantsCreator _plantsCreator;

        public bool IsFree { get; set; } = true;

        private void Start() => _plantsCreator = ServiceLocator.Container.GetService<PlantsCreator>();

        public void Click()
        {
            if(IsFree)
            {
                _plantsCreator.ActiveCell = this;
                OnClick?.Invoke();
            }
        }

        public void PointerExit() => OnPointerExit?.Invoke();
    }
}

