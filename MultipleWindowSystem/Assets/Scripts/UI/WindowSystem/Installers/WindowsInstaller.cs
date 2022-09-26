using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using Zenject;

namespace UI.WindowSystem.Installers
{
    public class WindowsInstaller : MonoInstaller
    {
        [SerializeField] private LeftController leftController;
        [SerializeField] private RightController rightController;
        
        public override void InstallBindings()
        {
            Container.BindInstance(leftController).AsSingle().NonLazy();
            Container.BindInstance(rightController).AsSingle().NonLazy();
            Container.Bind<StackControl>().AsTransient().WhenInjectedInto<WindowController>().NonLazy();
            BindSignals();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<DequeueWindowSignal>();
            Container.BindSignal<DequeueWindowSignal>()
                .ToMethod<LeftController>(_controller => _controller.ReceiveDequeueSignal).FromResolve();
            Container.BindSignal<DequeueWindowSignal>()
                .ToMethod<RightController>(_controller => _controller.ReceiveDequeueSignal).FromResolve();
        }
    }
}
