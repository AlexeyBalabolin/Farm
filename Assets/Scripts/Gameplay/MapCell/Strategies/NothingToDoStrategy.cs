using UnityEngine;

namespace Gameplay
{
    public class NothingToDoStrategy : ICellStrategy
    {
        public void Execute()
        {
            Debug.Log("Nothing");
        }
    }
}

