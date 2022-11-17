using UnityEngine;
using TMPro;
using Infrastructure.Factory;
using Infrastructure.Services;
using System;

namespace UI
{
    public class MapSize : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _widthDropdown, _heightDropdown;

        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            SetMapSize();
        }

        public void SetMapSize()
        {
            var wValue = _widthDropdown.value;
            int width = int.Parse(_widthDropdown.options[wValue].text);
            var hValue = _heightDropdown.value;
            int height = int.Parse(_heightDropdown.options[hValue].text);
            _gameFactory.MapSize = new Vector2(width + 2, height + 2);
        }
    }
}

