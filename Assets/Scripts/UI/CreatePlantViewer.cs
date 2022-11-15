using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CreatePlantViewer: MonoBehaviour
    {
        [SerializeField]
        private GameObject _createWindow;

        [SerializeField]
        private Button _grassButton, _carrotButton, _treeButton;

        public void ShowCreateWindow()
        {
            _createWindow.SetActive(true);
        }
    }
}
