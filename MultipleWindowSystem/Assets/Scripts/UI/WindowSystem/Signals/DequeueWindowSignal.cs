using UI.WindowSystem.Interfaces;

namespace UI.WindowSystem.Signals
{
    internal readonly struct DequeueWindowSignal
    {
        public DequeueWindowSignal(IWindowVisibility _window)
        {
            window = _window;
        }
        
        public readonly IWindowVisibility window;
    }
}
