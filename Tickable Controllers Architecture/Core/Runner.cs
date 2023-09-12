using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public abstract class Runner : IRunnable
    {
        private bool _canEnableAllControllers;
        private bool _isStarted = false;
        private readonly List<IController> _controllersWasEnabled = new();
        protected IController[] _controllers;

        protected Runner(bool enableAllControllers)
        {
            _canEnableAllControllers = enableAllControllers;
        }

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
            _controllersWasEnabled.ForEach(controller => controller.Enable());
            _controllersWasEnabled?.Clear();
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
            _controllersWasEnabled
                .AddRange(_controllers
                .Where(controller => controller.Enabled));

            _controllersWasEnabled.ForEach(controller => controller?.Disable());
        }
    }
}