using Zenject;

namespace UI.MachineManagers.MenuStates
{
    /// <summary>
    /// Class <c>MenuState</c> is <c>State</c> representation for each state in menu scene
    /// </summary>
    public class MenuState : State<MenuType,MenuTrigger>
    {
        /// <summary>
        /// Machine currently on scene
        /// </summary>
        /// <param name="_machine">Machine of <c>UIMenuMachine</c> type</param>
        [Inject]
        private void Init(UIMenuMachine _machine)
        {
            machine = _machine;
        }
        
        /// <summary>
        /// Sets own reference to state in UI machine 
        /// </summary>
        /// <param name="_actualMachineState">Actual state in machine</param>
        protected override void SetState(MenuType _actualMachineState)
        {
            if(_actualMachineState != state) return;
            machine.currentState = this;
        }
        
    }
}