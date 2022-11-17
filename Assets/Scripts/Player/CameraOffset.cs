using UnityEngine;

namespace Player
{
    public class CameraOffset : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _offsetVector;

        public Vector3 OffsetVector { get => _offsetVector; }
    }
}

