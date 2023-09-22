using UnityEngine;

namespace Assets.Package.Tokens
{
    public class TokenData : ScriptableObject, IIdentificatable, INamable
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}