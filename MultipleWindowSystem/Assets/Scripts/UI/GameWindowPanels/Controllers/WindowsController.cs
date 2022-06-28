using System.Collections.Generic;
using ModestTree;
using UI.MachineManagers;
using UnityEngine;
using Zenject;

namespace UI.GameWindowPanels.Controllers
{
    /// <summary>
    /// Abstract class manages opening and closing windows 
    /// </summary>
    public abstract class WindowsController : MonoBehaviour
    {
        /// <summary>
        /// Stack to holds windows (LIFO queue)
        /// </summary>
        private readonly Stack<IWindowView> windowsStack = new Stack<IWindowView>();

        protected virtual void Awake()
        {
            
        }

        private void Start()
        {
            ProjectContext.Instance.ResolveFromSceneContext<UIGameMachine>().AddToStackCheck(CheckIfStackIsEmpty);
        }

        /// <summary>
        /// Checks if stack has any window
        /// </summary>
        /// <returns>Returns bool depends on stack capacity</returns>
        private bool CheckIfStackIsEmpty() => windowsStack.IsEmpty();
        
        /// <summary>
        /// Enqueues windows of specific type 
        /// </summary>
        /// <typeparam name="T">Generic type implements IWindowView interface</typeparam>
        protected void Enqueue<T>() where T: IWindowView 
        {
            IWindowView window = ProjectContext.Instance.ResolveFromSceneContext<T>();
            if(window is null || windowsStack.Contains(window)) return;
        
            windowsStack.Push(window);
            window.Open();
            ProjectContext.Instance.ResolveFromSceneContext<UIGameMachine>().SelectWindow((ISelectableWindow)window);
        }

        /// <summary>
        /// Dequeues window from stack
        /// </summary>
        /// <param name="_windowToDequeue">Window to dequeue</param>
        public void Dequeue(IWindowView _windowToDequeue)
        {
            while (windowsStack.Count > 0)
            {
                IWindowView window = windowsStack.Pop();
                window.Close();

                if (window == _windowToDequeue) break;
            }
            
            if (windowsStack.Count == 0)
            {
                ProjectContext.Instance.ResolveFromSceneContext<UIGameMachine>().CheckStackForSortingIndexReset();
            }
        }
        

    }
}
