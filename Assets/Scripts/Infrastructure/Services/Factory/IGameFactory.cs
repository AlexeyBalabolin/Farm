using Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject Player { get; set; }

        GameObject Camera { get; set; }

        GameObject Hud { get; set; }

        GameObject FxPooler { get; set; }

        GameObject Audio { get; set; }

        Vector2 MapSize { get; set; }

        GameObject CreateGameobject(GameObject prefab);

        GameObject CreateGameobjectAtPoint(GameObject prefab, Transform spawnPoint);

        GameObject CreateFromResource(string path);

        GameObject CreateFromResourceAtPoint(string path, Transform spawnPoint);

        void DestroyObject(GameObject destroyedObject);

        List<ISavedProgress> ProgressSavers { get; }

        void AddProgressSaver(ISavedProgress progressSaver);

        void RemoveProgressSaver(ISavedProgress progressSaver);

        void Cleanup();
    }
}