using System.Collections.Generic;
using System.Linq;
using UI.WindowSystem.Interfaces;

namespace UI.WindowSystem.WindowControllers
{
    public class StackControl
    {
        private readonly Stack<IWindowVisibility> windowsStack = new Stack<IWindowVisibility>();
        
        public bool CheckIfStackContainsWindow<T>() where T: IWindowVisibility
        {
            return windowsStack.OfType<T>().Any();
        }

        public void Push(IWindowVisibility _window)
        {
            windowsStack.Push(_window);
        }

        public IWindowVisibility Peek()
        {
            return windowsStack.Peek();
        }

        public IWindowVisibility Pop()
        {
            return windowsStack.Pop();
        }

        public int GetStackCount()
        {
            return windowsStack.Count;
        }

        public bool Contains(IWindowVisibility _window)
        {
            return windowsStack.Contains(_window);
        }

        public bool CheckIfStackIsEmpty() => windowsStack.Count == 0;
    }
}