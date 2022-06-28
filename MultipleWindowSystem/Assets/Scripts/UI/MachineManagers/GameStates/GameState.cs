using Zenject;

namespace UI.MachineManagers.GameStates
{
    
    /// <summary>
    /// Class <c>GameState</c> is <c>State</c> representation for each state in game scene
    /// </summary>
    public class GameState : State<UIGameState,UIGameTrigger>
    {
        /// <summary>
        /// Machine currently on scene
        /// </summary>
        /// <param name="_machine">Machine of <c>UIGameMachine</c> type</param>
        [Inject]
        private void Init(UIGameMachine _machine)
        {
            machine = _machine;
        }
        
        /// <summary>
        /// Sets own reference to state in UI machine 
        /// </summary>
        /// <param name="_actualMachineState">Actual state in machine</param>
        protected override void SetState(UIGameState _actualMachineState)
        {
            if(_actualMachineState != state) return;
            machine.currentState = this;
        }
    }
}