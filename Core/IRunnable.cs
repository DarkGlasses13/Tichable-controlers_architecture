namespace Architecture_Base.Core
{
    public interface IRunnable : IRestartable
    {
        void Enable();
        void Tick();
        void FixedTick();
        void LateTick();
        void Disable();
    }
}