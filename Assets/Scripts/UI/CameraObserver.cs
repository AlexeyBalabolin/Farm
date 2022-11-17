using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

public class CameraObserver : MonoBehaviour
{
    private IGameFactory _gameFactory;
    private GameObject _observableObject;

    void Start()
    {
        _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
        _observableObject = _gameFactory.Camera;
    }

    void Update()
    {
        if (_observableObject != null)
            transform.LookAt(_observableObject.transform);
    }
}
