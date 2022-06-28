using UI.MachineManagers;
using UnityEngine;
using Zenject;

namespace DI.SceneInstallers
{
    public class UIGameInstaller : MonoInstaller
    {
        [SerializeField] private UIGameMachine machine;
        public override void InstallBindings()
        {
            Container.BindInstance(machine).NonLazy();
        }
    }
}
