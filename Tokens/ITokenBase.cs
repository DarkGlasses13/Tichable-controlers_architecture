using System.Threading.Tasks;

namespace Assets.Package.Tokens
{
    public interface ITokenBase<TData, TToken> where TData : TokenData where TToken : Token
    {
        void Initialize();
        Task InitializeAsync();
        TToken GetByID(string id, bool isUsed = false, bool willWse = true);
        TToken GetNewByID(string id, bool willWse = true);
    }
}