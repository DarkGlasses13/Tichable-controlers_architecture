using System;

namespace Architecture_Base.UI
{
    public interface IUIElement
    {
        void Hide(Action callback = null);
        void Show(Action callback = null);
    }
}