namespace Assets.Package.Tokens.Actors
{
    public abstract class Actor : Token
    {
        public ActorInstance Instance { get; }

        protected Actor(TokenData data, ActorInstance instance) : base(data)
        {
            Instance = instance;
        }
    }
}