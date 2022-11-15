using UnityEngine;

namespace Gameplay
{
    public class UseStrategy : ICellStrategy
    {
        public void Execute()
        {
            Debug.Log("Use");
        }
    }
}

