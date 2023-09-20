using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets.Package.Tokens
{
    public abstract class TokensBase<T> where T : IToken
    {
        protected List<T> _datas;

        public virtual async Task LoadDataAsync() => await Task.CompletedTask;
        public virtual void LoadData() { }

        public T GetByID(string id)
        {
            return _datas.SingleOrDefault(data => data.ID == id);
        }
    }
}
