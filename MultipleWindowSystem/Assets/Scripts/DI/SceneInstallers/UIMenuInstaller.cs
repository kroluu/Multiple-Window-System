using UI.MachineManagers;
using UnityEngine;
using Zenject;

namespace DI.SceneInstallers
{
    public class UIMenuInstaller : MonoInstaller
    {
        [SerializeField] private UIMenuMachine machine;
        public override void InstallBindings()
        {
            Container.BindInstance(machine);
        }
    }
}
