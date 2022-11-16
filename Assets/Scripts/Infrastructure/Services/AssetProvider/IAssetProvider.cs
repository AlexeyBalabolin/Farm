using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider:IService
    {
        GameObject LoadResourse(string resourcePath);
    }
}