using System.Collections.Generic;
using UnityEngine;

namespace Architecture_Base.Hierarchy_Building
{
    public class HierarchyBuilder
    {
        private readonly Dictionary<string, Transform> _parents = new();

        public Transform GetParent(string name, Transform root = null)
        {
            Transform parent;

            if (_parents.ContainsKey(name))
            {
                parent = _parents[name];
            }
            else
            {
                GameObject findedParent = GameObject.Find(name);

                if (findedParent == null)
                {
                    parent = new GameObject(name).transform;
                    parent.SetParent(root);
                    _parents.Add(name, parent);
                }
                else
                {
                    parent = findedParent.transform;
                }
            }

            return parent;
        }

        public void SetRoot(string name, Transform root = null)
        {
            if (_parents.ContainsKey(name))
            {
                _parents[name].SetParent(root);
            }
        }
    }
}