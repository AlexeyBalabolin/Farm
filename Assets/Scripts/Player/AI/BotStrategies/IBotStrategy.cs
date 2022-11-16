using System;

namespace BotAI
{
    public interface IBotStrategy
    {
        event Action OnChangeStrategy;
        void Execute();
    }
}
