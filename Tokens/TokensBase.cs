using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Package.Tokens
{
    public abstract class TokensBase<TData, TToken> : ITokenBase<TData, TToken> where TData : TokenData where TToken : Token
    {
        protected List<TData> _datas;
        private  readonly List<TToken> _pool = new();

        public virtual async Task InitializeAsync() => await Task.CompletedTask;
        public virtual void Initialize() { }

        public TData GetDataByID(string id)
        {
            return _datas.SingleOrDefault(data => data.ID == id);
        }

        public TToken GetByID(string id, bool isUsed = false, bool willWse = true)
        {
            TToken token = _pool
                .Where(token => token.IsInUse == isUsed)
                .FirstOrDefault(token => token.Data.ID == id);

            token ??= GetNewByID(id, willWse);

            return token;
        }

        public TToken GetNewByID(string id, bool willWse = true)
        {
            TToken token = CreateByID(id);

            if (token == null) 
                return null;

            _pool.Add(token);
            token.IsInUse = willWse;
            return token;
        }

        protected abstract TToken CreateByID(string id);
    }
}
