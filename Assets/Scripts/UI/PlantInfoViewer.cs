using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Gameplay;

namespace UI
{
    public class PlantInfoViewer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _infoWindow;

        [SerializeField]
        private TMP_Text _nameText, _descriptionText;

        [SerializeField]
        private Button _useButton;

        [SerializeField]
        private Image _plantImage;

        public void ShowInfoWindow(Plant plant)
        {
            _infoWindow.SetActive(true);
            
        }
    }
}
