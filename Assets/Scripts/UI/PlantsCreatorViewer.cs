using Gameplay;
using Infrastructure.Factory;
using Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BotAI;
using System.Linq;

namespace UI
{
    public class PlantsCreatorViewer: MonoBehaviour
    {
        [SerializeField]
        private GameObject _plantsWindow;

        [SerializeField]
        private Transform _buttonsParent;

        [SerializeField]
        private GameObject _createButtonPrefab;

        [SerializeField]
        private TMP_Text _plantName, _plantDescription;

        [SerializeField]
        private Button _grownButton, _closeButton;

        private PlantsCreator _plantsCreator;
        private BotStrategy _botStrategy;
        private IGameFactory _gameFactory;
        private Dictionary<Button, PlantData> _grownPlantDictionary = new Dictionary<Button, PlantData>();

        private void OnEnable()
        {
            _plantsCreator = ServiceLocator.Container.GetService<PlantsCreator>();
            _plantsCreator.OnActiveCellSelected += () => ShowPlantsWindow(_plantsCreator.ActiveCell);
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            CreateButtons();
        }

        private void OnDisable() => _plantsCreator.OnActiveCellSelected -= () => ShowPlantsWindow(_plantsCreator.ActiveCell);

        private void CreateButtons()
        {
            foreach(PlantData plant in _plantsCreator.PlantsList)
            {
                Button button = _gameFactory.CreateGameobjectAtPoint(_createButtonPrefab, _buttonsParent).GetComponent<Button>();
                button.GetComponent<Image>().sprite = plant.PlantSprite;
                RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
                buttonRectTransform.localScale = Vector3.one;
                _grownPlantDictionary.Add(button, plant);
            }
        }

        private void ShowPlantsWindow(Cell activeCell)
        {
            _plantsWindow.SetActive(true);
            foreach(var keyValuePair in _grownPlantDictionary)
            {
                keyValuePair.Key.onClick.RemoveAllListeners();
                keyValuePair.Key.onClick.AddListener(() => ShowPlantDescription(keyValuePair, activeCell));
            }
            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(() => ClosePlantWindow(activeCell));
            ShowPlantDescription(_grownPlantDictionary.First(), activeCell);
        }

        private void ShowPlantDescription(KeyValuePair<Button,PlantData> keyValuePair, Cell activeCell)
        {
            _plantName.text = keyValuePair.Value.Name;
            _plantDescription.text = keyValuePair.Value.Description;
            _grownButton.onClick.RemoveAllListeners();
            _grownButton.onClick.AddListener(() => GrownNewPlant(keyValuePair.Value, activeCell));
        }

        private void GrownNewPlant(PlantData plantData, Cell activeCell)
        {            
            activeCell.IsFree = false;
            ClosePlantWindow(activeCell);
            WalkPlayer(activeCell.transform.position);
            _botStrategy.OnEndPlanting.RemoveAllListeners();
            _botStrategy.OnEndPlanting.AddListener( () => 
            { 
                Sprout sprout = _gameFactory.CreateGameobjectAtPoint(plantData.SproutPrefab, activeCell.transform).GetComponent<Sprout>();
                sprout.StartGrown(plantData.GrowthTime, plantData, _gameFactory);
            });
        }

        private void WalkPlayer(Vector3 target)
        {
            if (_botStrategy == null)
                _botStrategy = _gameFactory.Player.GetComponent<BotStrategy>();
            _botStrategy.Target = target;
        }

        private void ClosePlantWindow(Cell activeCell)
        {
            activeCell.PointerExit();
            _plantsWindow.SetActive(false);
        }
    }
}
