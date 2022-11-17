using System;

namespace Infrastructure.Services
{
    public interface IScoreService : IService
    {
        int Carrots { get; }
        int Score { get; }

        event Action OnCarrotsChanged;
        event Action OnScoreChanged;

        void AddCarrot();
        void AddScore(int score);
    }
}