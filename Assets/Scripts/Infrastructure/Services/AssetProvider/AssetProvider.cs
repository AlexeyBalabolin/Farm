using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadResourse(string resourcePath) => (GameObject)Resources.Load(path:resourcePath);
    }
}