using UnityEngine;
using TMPro;
using Infrastructure.Services;

namespace UI
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _scoreText, _carrotsText;

        private IScoreService _scoreService;

        private void OnEnable()
        {
            _scoreService = ServiceLocator.Container.GetService<IScoreService>();
            _scoreService.OnScoreChanged += ChangeScoreText;
            _scoreService.OnCarrotsChanged += ChangeCarrotText;
        }

        private void OnDisable()
        {
            _scoreService.OnScoreChanged -= ChangeScoreText;
            _scoreService.OnCarrotsChanged -= ChangeCarrotText;
        }

        private void ChangeCarrotText() => _carrotsText.text = _scoreService.Carrots.ToString();

        private void ChangeScoreText() => _scoreText.text = _scoreService.Score.ToString();
    }
}
