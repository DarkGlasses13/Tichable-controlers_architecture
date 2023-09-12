using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public abstract class Controller : IController
    {
        public bool Enabled { get; private set; }

        public virtual async Task InitializeAsync() { await Task.CompletedTask; }

        public virtual void Initialize() { }

        public void Enable()
        {
            if (Enabled == false)
            {
                OnEnable();
                Enabled = true;
            }
        }

        protected virtual void OnEnable() { }

        public virtual void FixedTick() { }

        public virtual void LateTick() { }

        public virtual void Restart() { }

        public virtual void Tick() { }

        public void Disable()
        {
            if (Enabled)
            {
                Enabled = false;
                OnDisable();
            }
        }

        protected virtual void OnDisable() { }
    }
}
