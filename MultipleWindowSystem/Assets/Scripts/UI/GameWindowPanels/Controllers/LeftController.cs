using UI.GameWindowPanels.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameWindowPanels.Controllers
{
    public class LeftController : WindowsController
    {
        [Header("Buttons meant to open windows")]
        [SerializeField] private Button oneButton;
        [SerializeField] private Button twoButton;
        [SerializeField] private Button threeButton;
        [SerializeField] private Button fourButton;

        protected override void Awake()
        {
            base.Awake();
            oneButton.onClick.AddListener(Enqueue<OneWindow>);
            twoButton.onClick.AddListener(Enqueue<TwoWindow>);
            threeButton.onClick.AddListener(Enqueue<ThreeWindow>);
            fourButton.onClick.AddListener(Enqueue<FourWindow>);
        }
    }
}
