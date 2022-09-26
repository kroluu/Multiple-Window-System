using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using Zenject;

namespace UI.WindowSystem.Windows.ExtendedSecondWindow
{
    public sealed class ExtendedSecondWindowInstaller : MonoInstaller
    {
        [SerializeField] private ExtendedSecondWindow extendedSecondWindow;

        public override void InstallBindings()
        {
            Container.BindInstance(extendedSecondWindow).AsSingle().NonLazy();
            BindSignals();
        }
        
        private void BindSignals()
        {
            Container.DeclareSignal<EnqueueWindowSignal<ExtendedSecondWindow>>();
            Container.BindSignal<EnqueueWindowSignal<ExtendedSecondWindow>>()
                .ToMethod<RightController>(_controller => _controller.ReceiveEnqueueSignal).FromResolve();
        }
    }
}