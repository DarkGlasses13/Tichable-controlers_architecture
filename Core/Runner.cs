using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public abstract class Runner : IRunnable
    {
        protected bool _canEnableControllers = true;
        protected IController[] _controllers;
        protected IController[] _controllersToEnable;
        private readonly List<IController> _controllersWasEnabled = new();
        private bool _isEnabled = false;

        public async void RunAsync()
        {
            await CreateControllers();

            foreach (IController controller in _controllers)
            {
                await controller?.InitializeAsync();
                controller?.Initialize();
            }

            OnControllersInitialized();
            Enable();
            OnControllersEnabled();
        }

        protected abstract Task CreateControllers();
        protected abstract void OnControllersInitialized();

        public void Enable()
        {
            _isEnabled = true;

            if (_canEnableControllers == false)
                return;

            if (_controllersToEnable != null)
            {
                Array.ForEach(_controllersToEnable, controller => controller?.Enable());
                _controllersToEnable = null;
                return;
            }

            _controllersWasEnabled?.ForEach(controller => controller?.Enable());
            _controllersWasEnabled?.Clear();
        }

        protected abstract void OnControllersEnabled();

        public void Tick()
        {
            if (_isEnabled)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.Tick();
                };
        }

        public void LateTick()
        {
            if (_isEnabled)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.LateTick();
                };
        }

        public void FixedTick()
        {
            if (_isEnabled)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.FixedTick();
                };
        }

        public void Restart()
        {
            if (_isEnabled)
                foreach (IController controller in _controllers)
                {
                    if (controller.Enabled)
                        controller?.Restart();
                };
        }

        public void Disable()
        {
            _isEnabled = false;

            _controllersWasEnabled
                .AddRange(_controllers
                .Where(controller => controller.Enabled));

            _controllersWasEnabled.ForEach(controller => controller?.Disable());
        }
    }
}