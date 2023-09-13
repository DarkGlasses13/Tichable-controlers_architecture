using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public interface IAssetLoader<T>
    {
        object Key { get; }
        object Asset { get; }
        T Load();
        T LoadAll();
        T LoadAndInstantiate(Transform parent, bool isActive = true);
        Task<T> LoadAsync();
        Task<IList<T>> LoadAllAsync();
        Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        Task<IList<T>> LoadAndInstantiateAllAsync(Transform parent, bool isActive = true);
        void Unload();
    }
}