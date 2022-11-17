using Infrastructure;
using Infrastructure.Data;
using Infrastructure.GameStates;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _newGameButton, _continueButton, _quitButton;

        private GameStateMachine _gameStateMachine;
        private ISaveLoadService _saveLoadService;
        private const string ProgressKey = "Progress";

        public void Construct(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _newGameButton.onClick.AddListener(()
            => { _gameStateMachine.Enter<LoadLevelState, string>("Level"); PlayerPrefs.DeleteKey(ProgressKey); PlayerPrefs.Save(); _saveLoadService.Progress = new PlayerProgress(); });
            _quitButton.onClick.AddListener(Application.Quit);
            if (PlayerPrefs.HasKey(ProgressKey))
            {
                _continueButton.interactable = true;
                _continueButton.onClick.AddListener(() => _gameStateMachine.Enter<LoadLevelState>());
            }
        }
    }
}

