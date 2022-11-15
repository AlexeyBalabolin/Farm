using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InteractiveCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private PlayerInputs _inputActions;

        private void OnEnable()
        {
            if (_inputActions == null)
                _inputActions = new PlayerInputs();
            _inputActions.Player.Click.started += (ctx) => ShootRay(ctx.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _inputActions.Player.Click.started -= (ctx) => ShootRay(ctx.ReadValue<Vector2>());
        }

        private void ShootRay(Vector2 clickPoint)
        {
            Debug.Log("Click");
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(clickPoint);

            if (Physics.Raycast(ray, out hit))
            {
                TryGetComponent(out IClickable clickable);
                Debug.Log(hit.collider.name);
                clickable.Click();
            }
        }
    }
}

