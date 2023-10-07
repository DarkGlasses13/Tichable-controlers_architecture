using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture_Base.Core
{
    public abstract class Runner : IRunnable
    {
        private bool _isFirstRun = true;
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
            if (_isEnabled)
                return;

            _isEnabled = true;

            if (_isFirstRun)
            {
                _isFirstRun = false;

                if (_canEnableControllers == false)
                    return;

                IController[] controllers;

                if (_controllersToEnable != null)
                {
                    controllers = _controllersToEnable.ToArray();
                    _controllersToEnable = null;
                }
                else
                {
                    controllers = _controllers;
                }

                Array.ForEach(controllers, controller =>  controller?.Enable());
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
            if (_isEnabled == false)
                return;

            _isEnabled = false;

            _controllersWasEnabled
                .AddRange(_controllers
                .Where(controller => controller.Enabled));

            _controllersWasEnabled.ForEach(controller => controller?.Disable());
        }
    }
}