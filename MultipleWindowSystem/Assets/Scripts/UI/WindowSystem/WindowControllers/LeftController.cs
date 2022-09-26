using UI.WindowSystem.Windows;
using UI.WindowSystem.Windows.FirstWindow;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowSystem.WindowControllers
{
    internal class LeftController : WindowController
    {
        [SerializeField] private Button openFirstWindowButton;

        protected override void Awake()
        {
            base.Awake();
            openFirstWindowButton.onClick.AddListener(OpenWindow<FirstWindow>);
        }
        
        private void OpenWindow<TWindow>() where TWindow : OpenableWindow<LeftController>
        {
            if (stackControl.CheckIfStackContainsWindow<TWindow>())
            {
                DequeueAll();
                return;
            }
            ClearAndEnqueue<TWindow>();
        }
        
    }
}
