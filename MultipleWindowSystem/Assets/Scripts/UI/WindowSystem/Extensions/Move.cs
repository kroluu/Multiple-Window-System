using UI.WindowSystem.WindowControllers;
using UI.WindowSystem.Windows;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI.WindowSystem.Extensions
{
    [RequireComponent(typeof(OpenableWindow<WindowController>))]
    public class Move : MonoBehaviour, IDragHandler
    {
        private RectTransform windowRect;

        [SerializeField] private Canvas mainCanvas;
        /*
        private UIGameMachine gameMachine;
        protected void Construct(UIGameMachine _machine)
        {
            gameMachine = _machine;
        }*/
        private void Awake()
        {
            TryGetComponent(out windowRect);
        }

        public void OnDrag(PointerEventData eventData)
        {
            windowRect.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
        }
    }
}