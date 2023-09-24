using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public abstract class AssetLoader<T> : ISingleAssetLoader<T>
    {
        protected object _asset;

        public abstract object Key { get; }

        public abstract T Load();
        public abstract IList<T> LoadAll();
        public abstract Task<IList<T>> LoadAllAsync();
        public abstract T LoadAndInstantiate(Transform parent, bool isActive = true);
        public abstract Task<IList<T>> LoadAndInstantiateAllAsync(Transform parent, bool isActive = true);
        public abstract Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        public abstract Task<T> LoadAsync();

        public void Unload()
        {
            if (_asset != null)
            {
                if (_asset is GameObject gameObjectAsset)
                {
                    gameObjectAsset.SetActive(false);
                }

                ReleaseAsset();
                _asset = null;
            }
        }

        protected abstract void ReleaseAsset();
    }
}