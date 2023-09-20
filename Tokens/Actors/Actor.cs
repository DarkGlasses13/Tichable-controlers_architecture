using Architecture_Base.Asset_Loading;
using System;
using UnityEngine;

namespace Assets.Package.Tokens.Actors
{
    public abstract class Actor : IActor
    {
        private readonly IInstanceLoader _instanceLoader;
        private GameObject _instance;

        public ActorData Data { get; }
        public bool IsInUse { get; set; }
        public bool HasInstance => _instance != null;

        public Actor(IInstanceLoader instanceLoader, ActorData data)
        {
            _instanceLoader = instanceLoader;
            Data = data;
        }

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

        public void UnloadInstance(Action<GameObject> onBeforeUnload = null)
        {
            _instanceLoader.UnloadInstance(onBeforeUnload);
            OnInstanceUnloaded();
        }

        protected virtual void OnInstanceUnloaded() { }
    }
}