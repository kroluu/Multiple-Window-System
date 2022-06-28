namespace UI.MachineManagers.GameStates
{
    /// <summary>
    /// Class <c>GameMenuState</c> represents state transitions for main view in menu scene
    /// </summary>
    public class GameMainState : GameState
    {
        protected override void Awake()
        {
            machine.currentState = this;
            state = UIGameState.Main;
            base.Awake();
        }

        protected override void ConfigureMachineTransitions()
        {
            base.ConfigureMachineTransitions();
            machine.StateMachine.Configure(state)
                .Permit(UIGameTrigger.OpenMenu, UIGameState.Menu);
        }

        public override void ExecuteEscapeBehaviour()
        {
            base.ExecuteEscapeBehaviour();
            machine.StateMachine.Fire(UIGameTrigger.OpenMenu);
        }
    }
}
