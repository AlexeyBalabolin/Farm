using UnityEngine;

namespace Gameplay
{
    public class Tree : Plant
    {
        protected override void ActivatePlant() => Debug.Log("С деревом ничего нельзя сделать");
    }
}

