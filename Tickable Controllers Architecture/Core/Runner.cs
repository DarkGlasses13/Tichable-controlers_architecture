using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public abstract class Runner : IRunnable
    {
        protected bool _canEnableAllControllers = true;
        protected IController[] _controllers;
        private readonly List<IController> _controllersToEnabled = new();
        private bool _isStarted = false;

        public async void RunAsync()
        {
            await CreateControllers();

            foreach (IController controller in _controllers)
            {
                await controller?.InitializeAsync();
                controller?.Initialize();

                if (_canEnableAllControllers)
                {
                    controller?.Enable();
                }
            }

            _isStarted = true;
            OnControllersInitializedAndEnabled();
        }

        protected abstract Task CreateControllers();

        public void Enable()
        {
            _controllersToEnabled.ForEach(controller => controller.Enable());
            _controllersToEnabled?.Clear();
        }

        protected abstract void OnControllersInitializedAndEnabled();

        public void Tick()
        {
            if (_isStarted)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.Tick();
                };
        }

        public void LateTick()
        {
            if (_isStarted)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.LateTick();
                };
        }

        public void FixedTick()
        {
            if (_isStarted)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.FixedTick();
                };
        }

        public void Restart()
        {
            if (_isStarted)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.Restart();
                };
        }

        public void Disable()
        {
            _controllersToEnabled
                .AddRange(_controllers
                .Where(controller => controller.Enabled));

            _controllersToEnabled.ForEach(controller => controller?.Disable());
        }
    }
}