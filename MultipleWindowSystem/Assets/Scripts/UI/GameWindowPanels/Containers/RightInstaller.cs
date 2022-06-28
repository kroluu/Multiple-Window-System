using UI.GameWindowPanels.Controllers;
using UI.GameWindowPanels.Windows;
using UnityEngine;
using Zenject;

namespace UI.GameWindowPanels.Containers
{
    public class RightInstaller : MonoInstaller
    {
        [Header("Windows")]
        [SerializeField] private FiveWindow five;
        [SerializeField] private SixWindow six;
        [SerializeField] private SevenWindow seven;
    
        [Header("Installers")]
        [SerializeField] private RightController rightController;

        public override void InstallBindings()
        {
            Container.BindInstance(five).AsSingle().Lazy();
            Container.BindInstance(six).AsSingle().Lazy();
            Container.BindInstance(seven).AsSingle().Lazy();
            Container.BindInstance(rightController).AsSingle().Lazy();
        }
    }
}
