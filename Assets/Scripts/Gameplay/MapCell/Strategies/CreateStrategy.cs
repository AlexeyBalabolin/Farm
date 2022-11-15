using UnityEngine;

namespace Gameplay
{
    public class CreateStrategy : ICellStrategy
    {
        public void Execute()
        {
            Debug.Log("Create");
        }
    }
}

