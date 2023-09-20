using System.Collections.Generic;
using System.Linq;

namespace Assets.Package.Tokens.Actors
{
    public abstract class ActorsBase<TData, TActor> : TokensBase<TData> where TData : ActorData where TActor : Actor
    {
        private readonly List<TActor> _actors = new();

        public TActor GetByID(string id, bool isUsed = false, bool willWse = true)
        {
            TActor actor = _actors
                .Where(actor => actor.IsInUse == isUsed)
                .FirstOrDefault(actor => actor.Data.ID == id);

            actor ??= GetNewByID(id, willWse);

            return actor;
        }

        public TActor GetNewByID(string id, bool willWse = true)
        {
            TActor created = CreateByID(id);
            _actors.Add(created);
            created.IsInUse = willWse;
            return created;
        }

        protected abstract TActor CreateByID(string id);
    }
}
