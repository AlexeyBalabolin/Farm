using Gameplay;
using UnityEngine;

namespace Player
{
    public class InstrumentCameraDragger : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private bool _isDragging;
        private InstrumentType _instrumentType;
        private PlayerInputs _inputActions;

        private void OnEnable()
        {
            _inputActions = new PlayerInputs();
            _inputActions.Player.PointerPosition.performed += (ctx) => InstrumentActivation(ctx.ReadValue<Vector2>());
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Player.PointerPosition.performed -= (ctx) => InstrumentActivation(ctx.ReadValue<Vector2>());
            _inputActions.Dispose();
        }

        public void StartDragging(InstrumentType instrumentType)
        {
            _isDragging = true;
            _instrumentType = instrumentType;
        }

        public void StopDragging() => _isDragging = false;

        private void InstrumentActivation(Vector2 position)
        {
            if(_isDragging)
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(position);

                if (Physics.Raycast(ray, out hit))
                {
                    hit.collider.TryGetComponent(out IPointerEnter pointerEnter);
                    pointerEnter?.PointerEnter(_instrumentType);
                }
            }
        }
    }
}

