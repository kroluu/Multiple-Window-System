using System;
using System.Collections.Generic;
using System.Linq;
using Core.Settings;
using UI.GameWindowPanels;

namespace UI.MachineManagers
{
    /// <summary>
    /// Class <c>UIGameMachine</c> extends <c>UIMachine</c> behaviour by functionalities used in game scene. Designed to controls states in game scene
    /// </summary>
    public class UIGameMachine : UIMachine<UIGameState, UIGameTrigger>
    {
        public ISelectableWindow currentSelectedWindow;
        
        private int windowSortingIndex = Config.DEFAULT_GAME_SORTING_INDEX;
    
        /// <summary>
        /// List of methods that checks if stack has any window
        /// </summary>
        private readonly List<Func<bool>> controllersStackCheck = new List<Func<bool>>();
    
        /// <summary>
        /// Adds method to list if not already added
        /// </summary>
        /// <param name="_method">Checks if stack contains any window</param>
        public void AddToStackCheck(Func<bool> _method)
        {
            if(controllersStackCheck.Contains(_method)) return;
            controllersStackCheck.Add(_method);
        }

        /// <summary>
        /// Iterates through func list and reset sorting index if all methods return true
        /// </summary>
        public void CheckStackForSortingIndexReset()
        {
            if (controllersStackCheck.Any(_x => !_x.Invoke()))
            {
                return;
            }

            windowSortingIndex = Config.DEFAULT_GAME_SORTING_INDEX;
        }
    
        /// <summary>
        /// Deselects previous window and selects the one passed in the parameter
        /// </summary>
        /// <param name="_windowToSelect">Window to select</param>
        public void SelectWindow(ISelectableWindow _windowToSelect)
        {
            if(currentSelectedWindow == _windowToSelect) return;
            
            currentSelectedWindow?.DeselectWindow();
            currentSelectedWindow = _windowToSelect;
            currentSelectedWindow.SetSortingIndex(windowSortingIndex++);
            currentSelectedWindow.SelectWindow();
        }
    }
}