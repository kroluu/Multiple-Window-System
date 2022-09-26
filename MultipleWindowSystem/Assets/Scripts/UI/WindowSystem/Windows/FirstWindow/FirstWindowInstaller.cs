using UnityEngine;
using Zenject;

namespace UI.WindowSystem.Windows.FirstWindow
{
    public sealed class FirstWindowInstaller : MonoInstaller
    {
        [SerializeField] private FirstWindow firstWindow;
    
        public override void InstallBindings()
        {
            Container.BindInstance(firstWindow).AsSingle().NonLazy();
        }
    }
}
