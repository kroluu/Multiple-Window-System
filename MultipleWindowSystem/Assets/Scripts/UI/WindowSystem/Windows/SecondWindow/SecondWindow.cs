using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowSystem.Windows.SecondWindow
{
    internal sealed class SecondWindow : OpenableWindow<LeftController>
    {
        [SerializeField] private Button openSecondButton;

        protected override void Awake()
        {
            base.Awake();
            openSecondButton.onClick.AddListener(() =>
            {
                signalBus.TryFire(new EnqueueWindowSignal<ExtendedSecondWindow.ExtendedSecondWindow>());
            });
        }
    }
}