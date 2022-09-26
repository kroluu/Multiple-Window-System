using System;
using System.Collections.Generic;
using System.Linq;
using UI.WindowSystem.Interfaces;
using UI.WindowSystem.Signals;
using UI.WindowSystem.Windows;
using UnityEngine;
using Zenject;

namespace UI.WindowSystem.WindowControllers
{
    internal abstract class WindowController : MonoBehaviour
    {
        [Inject]
        protected StackControl stackControl;

        private const int DEFAULT_GAME_SORTING_INDEX = 1;

        /// <summary>
        /// List of methods that checks if stack has any window
        /// </summary>
        private readonly List<Func<bool>> controllersStackCheck = new List<Func<bool>>();
        
        /// <summary>
        /// Current window's sorting index
        /// </summary>
        private static int WindowSortingIndex = DEFAULT_GAME_SORTING_INDEX;
        
        /// <summary>
        /// Current selected window that has the highest order in UI
        /// </summary>
        private static ISelectableWindow CURRENT_SELECTED_WINDOW;

        protected virtual void Awake()
        {
            
        }

        private void Start()
        {
            AddToStackCheck(stackControl.CheckIfStackIsEmpty);
        }
        
        /// <summary>
        /// Adds method to list if not already added
        /// </summary>
        /// <param name="_method">Checks if stack contains any window</param>
        private void AddToStackCheck(Func<bool> _method)
        {
            if(controllersStackCheck.Contains(_method)) return;
            controllersStackCheck.Add(_method);
        }
        
        /// <summary>
        /// Iterates through func list and reset sorting index if all methods return true
        /// </summary>
        private void CheckStackForSortingIndexReset()
        {
            if (controllersStackCheck.Any(_x => !_x.Invoke()))
            {
                return;
            }

            WindowSortingIndex = WindowSortingIndex;
        }
    
        /// <summary>
        /// Deselects previous window and selects the one passed in the parameter
        /// </summary>
        /// <param name="_windowToSelect">Window to select</param>
        public static void SelectWindow(ISelectableWindow _windowToSelect)
        {
            CURRENT_SELECTED_WINDOW?.DeselectWindow();
            CURRENT_SELECTED_WINDOW = _windowToSelect;
            CURRENT_SELECTED_WINDOW.SetSortingIndex(WindowSortingIndex++);
            CURRENT_SELECTED_WINDOW.SelectWindow();
        }

        protected void ClearAndEnqueue<T>() where T : IWindowVisibility
        {
            DequeueAll();
            Enqueue<T>();
        }

        public void SecureEnqueue<T>() where T : IWindowVisibility
        {
            if(stackControl.CheckIfStackContainsWindow<T>()) return;
            ClearAndEnqueue<T>();
        }
        
        public void Enqueue<T>() where T: IWindowVisibility 
        {
            IWindowVisibility window = ProjectContext.Instance.ResolveFromSceneContext<T>();
            if(window is null || stackControl.Contains(window)) return;

            TryHidePreviousWindow();
            stackControl.Push(window);
            window.Open();
            SelectWindow((ISelectableWindow)window);
        }

        private void TryHidePreviousWindow()
        {
            if (stackControl.CheckIfStackIsEmpty()) return;
            
            HidePreviousWindow();
        }

        private void HidePreviousWindow()
        {
            if (stackControl.Peek() is IVisibilityOverride visibilityOverride)
            {
                visibilityOverride.OverrideVisibility();
            }
        }

        private void TryShowPreviousWindow()
        {
            if(stackControl.CheckIfStackIsEmpty()) return;
            
            ShowPreviousWindow();
        }

        private void ShowPreviousWindow()
        {
            if (stackControl.Peek() is IVisibilityOverride visibilityOverride)
            {
                visibilityOverride.RestoreWindow();
            }
        }

        public void Dequeue(IWindowVisibility _windowToDequeue)
        {
            if(!stackControl.Contains(_windowToDequeue)) return;
            while (stackControl.GetStackCount() > 0)
            {
                IWindowVisibility window = stackControl.Pop();
                window.Close();

                if (window == _windowToDequeue)
                {
                    TryShowPreviousWindow();
                    break;
                }
            }
            
            if (stackControl.GetStackCount() == 0)
            {
                CheckStackForSortingIndexReset();
            }
        }

        protected void DequeueAll()
        {
            while (stackControl.GetStackCount() > 0)
            {
                IWindowVisibility window = stackControl.Pop();
                window.Close();
            }
        }

        public void ReceiveDequeueSignal(DequeueWindowSignal _dequeueWindowSignal)
        {
            Dequeue(_dequeueWindowSignal.window);
        }

        public void ReceiveEnqueueSignal<T>(EnqueueWindowSignal<T> _enqueueWindowSignal) where T: IWindowVisibility
        {
            Enqueue<T>();
        }
    }
}
