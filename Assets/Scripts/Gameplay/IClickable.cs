using System;

namespace Gameplay
{
    public interface IClickable
    {
        event Action OnClick;
        void Click();
    }
}

