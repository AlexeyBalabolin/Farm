using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Gameplay;

namespace UI
{
    public class CellInfoViewer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _infoWindow;

        [SerializeField]
        private TMP_Text _nameText, _descriptionText;

        [SerializeField]
        private Button _useButton;

        [SerializeField]
        private Image _plantImage;

        public void ShowInfoWindow(Plant plant, ICellStrategy cellStrategy)
        {
            _infoWindow.SetActive(true);
            _nameText.text = plant.Name;
            _descriptionText.text = plant.Description;
            _plantImage.sprite = plant.PlantSprite;
            _useButton.onClick.AddListener(cellStrategy.Execute);
        }
    }
}
