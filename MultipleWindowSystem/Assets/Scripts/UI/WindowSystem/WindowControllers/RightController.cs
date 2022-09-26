using UI.WindowSystem.Windows;
using UI.WindowSystem.Windows.SecondWindow;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowSystem.WindowControllers
{
    internal class RightController : WindowController
    {
        [SerializeField] private Button openSecondWindowButton;

        protected override void Awake()
        {
            base.Awake();
            openSecondWindowButton.onClick.AddListener(OpenWindow<SecondWindow>);
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