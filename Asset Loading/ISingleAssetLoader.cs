using System.Threading.Tasks;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public interface ISingleAssetLoader<T>
    {
        object Key { get; }
        T Load();
        T LoadAndInstantiate(Transform parent, bool isActive = true);
        Task<T> LoadAsync();
        Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        void Unload();
    }
}