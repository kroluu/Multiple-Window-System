using System;
using UI.GameWindowPanels.Controllers;
using UI.MachineManagers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI.GameWindowPanels.Windows.Extensions
{
    [RequireComponent(typeof(OpenableWindow<WindowsController>))]
    public class Move : MonoBehaviour, IDragHandler
    {
        private RectTransform windowRect;

        [Inject]
        private UIGameMachine gameMachine;
        private void Awake()
        {
            TryGetComponent(out windowRect);
        }

        public void OnDrag(PointerEventData eventData)
        {
            windowRect.anchoredPosition += eventData.delta / gameMachine.Canvas.scaleFactor;
        }
    }
}
