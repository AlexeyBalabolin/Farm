using Gameplay;
using UnityEngine;

namespace Player
{
    public class InteractiveCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private PlayerInputs _inputActions;
        private Vector2 _pointerPosition;

        private void OnEnable()
        {
            _inputActions = new PlayerInputs();
            _inputActions.Player.PointerPosition.performed += (ctx) => _pointerPosition = ctx.ReadValue<Vector2>();
            _inputActions.Player.Click.started += Click_started;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Player.PointerPosition.performed -= (ctx) => _pointerPosition = ctx.ReadValue<Vector2>();
            _inputActions.Player.Click.started -= Click_started;
            _inputActions.Dispose();           
        }

        private void Click_started(UnityEngine.InputSystem.InputAction.CallbackContext obj) => ShootClickRay(_pointerPosition);

        private void ShootClickRay(Vector2 clickPoint)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(clickPoint);

            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.TryGetComponent(out IClickable clickable);
                clickable?.Click();
            }
        }
    }
}

