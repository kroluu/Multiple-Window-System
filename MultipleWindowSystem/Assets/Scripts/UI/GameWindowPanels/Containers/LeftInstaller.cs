using UI.GameWindowPanels.Controllers;
using UI.GameWindowPanels.Windows;
using UnityEngine;
using Zenject;

namespace UI.GameWindowPanels.Containers
{
    public class LeftInstaller : MonoInstaller
    {
        [Header("Windows")]
        [SerializeField] private OneWindow one;
        [SerializeField] private TwoWindow two;
        [SerializeField] private ThreeWindow three;
        [SerializeField] private FourWindow four;
    
        [Header("Installers")]
        [SerializeField] private LeftController leftController;
    
        public override void InstallBindings()
        {
            Container.BindInstance(one).AsSingle().Lazy();
            Container.BindInstance(two).AsSingle().Lazy();
            Container.BindInstance(three).AsSingle().Lazy();
            Container.BindInstance(four).AsSingle().Lazy();
            Container.BindInstance(leftController).AsSingle().Lazy();
        }
    }
}
