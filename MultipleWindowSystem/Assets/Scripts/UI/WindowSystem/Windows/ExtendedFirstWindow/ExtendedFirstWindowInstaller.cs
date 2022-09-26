using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using Zenject;

namespace UI.WindowSystem.Windows.ExtendedFirstWindow
{
    public sealed class ExtendedFirstWindowInstaller : MonoInstaller
    {
        [SerializeField] private ExtendedFirstWindow extendedFirstWindow;

        public override void InstallBindings()
        {
            Container.BindInstance(extendedFirstWindow).AsSingle().NonLazy();
            BindSignals();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<EnqueueWindowSignal<ExtendedFirstWindow>>();
            Container.BindSignal<EnqueueWindowSignal<ExtendedFirstWindow>>()
                .ToMethod<LeftController>(_controller => _controller.ReceiveEnqueueSignal).FromResolve();
        }
    }
}