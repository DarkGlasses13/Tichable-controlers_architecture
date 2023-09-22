using Architecture_Base.Asset_Loading;
using System;
using UnityEngine;

namespace Assets.Package.Tokens.Actors
{
    public abstract class Actor : Token, IInstanceLoader
    {
        private readonly IInstanceLoader _instanceLoader;
        private GameObject _instance;

        protected Actor(TokenData data, IInstanceLoader instanceLoader) : base(data)
        {
            _instanceLoader = instanceLoader;
        }

        public bool HasInstance => _instance != null;

        public GameObject GetInstance(string id, Action<GameObject> onLoaded = null)
        {
            _instance = _instanceLoader.GetInstance(id, onLoaded);
            OnInstanceLoaded(_instance);
            return _instance;
        }

        public GameObject GetInstance(string id, Vector3 position, Quaternion rotation, Transform parent, Action<GameObject> onLoaded = null)
        {
            _instance = _instanceLoader.GetInstance(id, position, rotation, parent, onLoaded);
            OnInstanceLoaded(_instance);
            return _instance;
        }

        protected virtual void OnInstanceLoaded(GameObject instance) 
        {
            instance
                .AddComponent<ActorInstance>()
                .Construct(Data.ID);
        }

        public void UnloadInstance()
        {
            _instanceLoader.UnloadInstance();
            OnInstanceUnloaded();
        }

        protected virtual void OnInstanceUnloaded() { }
    }
}