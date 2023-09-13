using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public abstract class AssetLoader<T> : IAssetLoader<T>
    {
        public abstract object Key { get; }
        public object Asset { get; protected set; }

        public abstract T Load();
        public abstract IList<T> LoadAll();
        public abstract Task<IList<T>> LoadAllAsync();
        public abstract T LoadAndInstantiate(Transform parent, bool isActive = true);
        public abstract Task<IList<T>> LoadAndInstantiateAllAsync(Transform parent, bool isActive = true);
        public abstract Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        public abstract Task<T> LoadAsync();

        public void Unload()
        {
            if (Asset != null)
            {
                if (Asset is GameObject gameObjectAsset)
                {
                    gameObjectAsset.SetActive(false);
                }

                ReleaseAsset();
                Asset = null;
            }
        }

        protected abstract void ReleaseAsset();
    }
}