using Infrastructure.Factory;
using Infrastructure.Services;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class Instrument : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        private InstrumentType _instrumentType;
        private Vector3 _startTransform;
        private InstrumentCameraDragger _instrumentCamera;
        private IGameFactory _gameFactory;


        public void Construct(InstrumentType instrumentType)
        {
            _instrumentType = instrumentType;
            _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
            _instrumentCamera = _gameFactory.Camera.GetComponentInChildren<InstrumentCameraDragger>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(_startTransform == Vector3.zero)
                _startTransform = transform.position;
            _instrumentCamera.StartDragging(_instrumentType);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = _startTransform;
            _instrumentCamera.StopDragging();
        }
    }
}
