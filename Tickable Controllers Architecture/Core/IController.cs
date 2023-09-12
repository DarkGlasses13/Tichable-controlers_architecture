using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public interface IController : IRunnable
    {
        bool Enabled { get; }

        Task InitializeAsync();
        void Initialize();
    }
}