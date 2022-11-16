using System;

namespace BotAI
{
    public class WorkingStrategy : IBotStrategy
    {
        public event Action OnChangeStrategy;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
