using UI.GameWindowPanels.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameWindowPanels.Controllers
{
    public class RightController : WindowsController
    {
        [SerializeField] private Button fiveButton;
        [SerializeField] private Button sixButton;
        [SerializeField] private Button sevenButton;

        private void Awake()
        {
            fiveButton.onClick.AddListener(Enqueue<FiveWindow>);
            sixButton.onClick.AddListener(Enqueue<SixWindow>);
            sevenButton.onClick.AddListener(Enqueue<SevenWindow>);
        }
    }
}
