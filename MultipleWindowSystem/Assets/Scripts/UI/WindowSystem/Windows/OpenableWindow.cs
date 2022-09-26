using DG.Tweening;
using UI.WindowSystem.Interfaces;
using UI.WindowSystem.Signals;
using UI.WindowSystem.WindowControllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace UI.WindowSystem.Windows
{
    [RequireComponent(typeof(CanvasGroup),typeof(Canvas))]
    internal abstract class OpenableWindow<T> : MonoBehaviour, IWindowVisibility, ISelectableWindow, IPointerClickHandler where T: WindowController
    {
        private static float TIME_FOR_WINDOW_APPEARANCE = 0.25f;
        private static float TIME_FOR_WINDOW_HIDE = 0.1f;
        
        private CanvasGroup canvasGroup;
        private Canvas canvas;
        [Header("References")]
        [SerializeField] protected Button closeButton;
        
        [Inject]
        protected SignalBus signalBus;
        protected virtual void Awake()
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
            closeButton?.onClick.AddListener(() =>
            {
                signalBus.Fire(new DequeueWindowSignal(this));
            });
        }

        private void AssignComponents()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();
        }

        public void Open(bool _immediatelyShow=false)
        {
            canvasGroup.DOKill();
            canvasGroup.DOFade(1f, _immediatelyShow ? 0f: TIME_FOR_WINDOW_APPEARANCE).OnStart(() =>
            {
                canvas.enabled = true;
                canvasGroup.blocksRaycasts = true;
            });
        }

        public void Close(bool _immediatelyHide=false)
        {
            canvasGroup.DOKill();
            canvasGroup.DOFade(0f, _immediatelyHide ? 0f: TIME_FOR_WINDOW_HIDE).OnComplete(() =>
            {
                canvasGroup.blocksRaycasts = false;
                canvas.enabled = false;
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
            WindowController.SelectWindow(this);
            //ProjectContext.Instance.ResolveFromSceneContext<T>().SelectWindow(this);
        }
    }
}