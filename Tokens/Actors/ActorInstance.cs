using UnityEngine;

namespace Assets.Package.Tokens.Actors
{
    public class ActorInstance : MonoBehaviour, IIdentificatable
    {
        public string ID { get; private set; }

        public void Construct(string id) => ID = id;
    }
}