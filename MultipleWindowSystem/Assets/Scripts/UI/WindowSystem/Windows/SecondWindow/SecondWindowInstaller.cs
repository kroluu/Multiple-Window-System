using UnityEngine;
using Zenject;

namespace UI.WindowSystem.Windows.SecondWindow
{
    public sealed class SecondWindowInstaller : MonoInstaller
    {
        [SerializeField] private SecondWindow secondWindow;
        
        public override void InstallBindings()
        {
            Container.BindInstance(secondWindow).AsSingle().NonLazy();
        }
    }
}