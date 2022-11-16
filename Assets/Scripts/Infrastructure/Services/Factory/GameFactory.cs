using Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private GameObject _player;

        public GameObject Player 
        {
            get => _player;
            set 
            {
                _player = value;
            }
        }

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        //создать объект по префабу
        public GameObject CreateGameobject(GameObject prefab)
        {
            var createdObject = UnityEngine.Object.Instantiate(prefab);
            return createdObject;
        }

        //создать объект в конкретной точке
        public GameObject CreateGameobjectAtPoint(GameObject prefab, Transform spawnPoint)
        {
            var createdObject = UnityEngine.Object.Instantiate(prefab,
                spawnPoint.transform.position, spawnPoint.transform.rotation);
            createdObject.transform.SetParent(spawnPoint);
            return createdObject;
        }

        //создать объект по пути к ресурсу
        public GameObject CreateFromResource(string resourcePath)
        {
            var createdObject = UnityEngine.Object.Instantiate(_assetProvider.LoadResourse(resourcePath));
            return createdObject;
        }

        public GameObject CreateFromResourceAtPoint(string resourcePath, Transform spawnPoint)
        {
            var createdObject = UnityEngine.Object.Instantiate(_assetProvider.LoadResourse(resourcePath), spawnPoint.position, spawnPoint.rotation);
            return createdObject;
        }

        //тут хранятся все компоненты, умеющие читать/записывать прогресс
        public List<ISavedProgress> ProgressSavers { get; } = new List<ISavedProgress>();

        //зарегистрировать компонент, умеющий читать/записывать прогресс
        public void AddProgressSaver(ISavedProgress progressSaver) => ProgressSavers.Add(progressSaver);

        //очистить список компонентов, сохраняющих прогресс
        public void Cleanup() => ProgressSavers.Clear();

        public void RemoveProgressSaver(ISavedProgress progressSaver) => ProgressSavers.Remove(progressSaver);

        public void DestroyObject(GameObject destroyedObject) => Object.Destroy(destroyedObject);
    }
}
