using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowSystem.Windows.FirstWindow
{
    internal sealed class FirstWindow : OpenableWindow<LeftController>
    {
        [SerializeField] private Button openSecondButton;

        protected override void Awake()
        {
            base.Awake();
            openSecondButton.onClick.AddListener(() =>
            {
                signalBus.Fire(new EnqueueWindowSignal<ExtendedFirstWindow.ExtendedFirstWindow>());
            });
        }
    }
}
