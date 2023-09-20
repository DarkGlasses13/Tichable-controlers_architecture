using UnityEngine;

namespace Assets.Package.Tokens
{
    public abstract class Token : ScriptableObject, IToken
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}