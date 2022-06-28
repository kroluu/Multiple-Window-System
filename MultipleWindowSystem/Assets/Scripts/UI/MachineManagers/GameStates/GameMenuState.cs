namespace UI.MachineManagers.GameStates
{
    /// <summary>
    /// Class <c>GameMenuState</c> represents state transitions for menu view in menu scene
    /// </summary>
    public class GameMenuState : GameState
    {
        protected override void Awake()
        {
            state = UIGameState.Menu;
            base.Awake();
        }

        protected override void ConfigureMachineTransitions()
        {
            base.ConfigureMachineTransitions();
            machine.StateMachine.Configure(state)
                .Permit(UIGameTrigger.BackToMain, UIGameState.Main);
        }

        public override void ExecuteEscapeBehaviour()
        {
            base.ExecuteEscapeBehaviour();
            machine.StateMachine.Fire(UIGameTrigger.BackToMain);
        }
    }
}
