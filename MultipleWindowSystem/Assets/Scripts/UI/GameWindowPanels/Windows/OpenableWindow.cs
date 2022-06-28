using DG.Tweening;
using UI.GameWindowPanels.Controllers;
using UI.MachineManagers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace UI.GameWindowPanels
{
    [RequireComponent(typeof(CanvasGroup),typeof(Canvas))]
    public abstract class OpenableWindow<T> : MonoBehaviour, IWindowView, ISelectableWindow, IPointerClickHandler where T: WindowsController
    {
        private CanvasGroup canvasGroup;
        private Canvas canvas;
        [Header("References")]
        [SerializeField] protected Button closeButton;
        private void Awake()
        {
            AssignComponents();
            BindListeners();
        }

        protected virtual void BindListeners()
        {
            BindCloseButton();
        }

        protected virtual void BindCloseButton()
        {
            closeButton.onClick.AddListener(() =>
            {
                var bind = ProjectContext.Instance.ResolveFromSceneContext<T>();
                bind.Dequeue(_windowToDequeue: this);
            });
        }

        private void AssignComponents()
        {
            TryGetComponent(out canvasGroup);
            TryGetComponent(out canvas);
        }
        
        public void Open()
        {
            canvasGroup.DOFade(1f, 0.25f).OnStart(() =>
            {
                canvasGroup.blocksRaycasts = true;
            });
        }

        public void Close()
        {
            canvasGroup.DOFade(0f, 0.25f).OnComplete(() =>
            {
                canvasGroup.blocksRaycasts = false;
            });
        }

        public void SetSortingIndex(int _index)
        {
            canvas.sortingOrder = _index;
        }

        public void SelectWindow()
        {
            canvas.overrideSorting = true;
        }

        public void DeselectWindow()
        {
            
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            ProjectContext.Instance.ResolveFromSceneContext<UIGameMachine>().SelectWindow(this);
        }
    }
}