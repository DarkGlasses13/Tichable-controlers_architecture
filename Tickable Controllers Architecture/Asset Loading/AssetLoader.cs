using System.Threading.Tasks;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public abstract class AssetLoader<T> : IAssetLoader<T>
    {
        public abstract string Key { get; }
        public object Asset { get; protected set; }

        public abstract T Load();
        public abstract T LoadAndInstantiate(Transform parent);
        public abstract Task<T> LoadAndInstantiateAsync(Transform parent);
        public abstract Task<T> LoadAsync();

        public void Unload()
        {
            if (Asset != null)
            {
                if (Asset is GameObject asset)
                {
                    asset.SetActive(false);
                }

                ReleaseAsset();
                Asset = null;
            }
        }

        protected abstract void ReleaseAsset();
    }
}