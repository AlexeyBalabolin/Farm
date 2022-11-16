using Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CreatePlantViewer: MonoBehaviour
    {
        [SerializeField]
        private GameObject _plantsWindow;

        [SerializeField]
        private AllPlants _allPlants;

        [SerializeField]
        private Button _createButtonPrefab;

        private List<Button> _plantButtons;

        private void OnEnable()
        {
            CreatePlantButtons(_allPlants);
            
        }

        private void CreatePlantButtons(AllPlants allPlants)
        {
            foreach (PlantData plant in allPlants)
            {
                Button createPlantButton = Instantiate(_createButtonPrefab);
                createPlantButton.GetComponentInChildren<Image>().sprite = plant.PlantSprite;
                _plantButtons.Add(createPlantButton);
                createPlantButton.onClick.AddListener(() => GrownPlane(plant.Prefab, _currentCell.transform.position));
            }
        }

        private void ShowPlantsWindow(Cell curentCell)
        {
            _plantsWindow.gameObject.SetActive(true);
            curentCell.OnClick += () => GrownPlane(curentCell.transform.position);
        }

        private void GrownPlane(GameObject plantPrefab, Vector3 position)
        {

        }       
    }
}
