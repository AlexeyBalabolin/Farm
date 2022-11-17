using System;

namespace Infrastructure.Services
{
    public class ScoreService : IScoreService
    {
        public event Action OnScoreChanged, OnCarrotsChanged;

        public int Score { get; private set; }
        public int Carrots { get; private set; }

        public void AddCarrot()
        {
            Carrots += 1;
            OnCarrotsChanged?.Invoke();
        }

        public void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke();
        }
    }
}

