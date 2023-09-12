using UnityEngine;

namespace Architecture_Base.Parent_Container_Creation
{
    public class ParentContainerCreator
    {
        public Transform Create(string name, Transform parent = null)
        {
            GameObject container = new(name);
            container.transform.SetParent(parent);
            return container.transform;
        }
    }
}