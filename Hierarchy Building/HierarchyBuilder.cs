using System.Collections.Generic;
using UnityEngine;

namespace Architecture_Base.Hierarchy_Building
{
    public class HierarchyBuilder
    {
        private readonly Dictionary<string, Transform> _parents = new();

        public Transform GetParent(string name, Transform root = null)
        {
            Transform parent = _parents.ContainsKey(name)
                ? _parents[name]
                : new GameObject(name).transform;

            parent.SetParent(root);
            return parent;
        }
    }
}