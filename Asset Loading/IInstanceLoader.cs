using System;
using UnityEngine;

namespace Architecture_Base.Asset_Loading
{
    public interface IInstanceLoader
    {
        bool HasInstance { get; }

        GameObject GetInstance(string id, Action<GameObject> onLoaded = null);
        GameObject GetInstance(string id, Vector3 position, Quaternion rotation,
            Transform parent, Action<GameObject> onLoaded = null);
        void UnloadInstance();
    }
}