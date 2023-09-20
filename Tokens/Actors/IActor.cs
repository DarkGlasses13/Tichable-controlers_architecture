using Architecture_Base.Asset_Loading;

namespace Assets.Package.Tokens.Actors
{
    public interface IActor : IInstanceLoader
    {
        ActorData Data { get; }
    }
}