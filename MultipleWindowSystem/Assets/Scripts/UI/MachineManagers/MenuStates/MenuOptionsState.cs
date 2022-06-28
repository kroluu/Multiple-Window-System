namespace UI.MachineManagers.MenuStates
{
    public class MenuOptionsState : MenuState
    {
        protected override void Awake()
        {
            state = MenuType.Options;
            base.Awake();
        }
        
        protected override void ConfigureMachineTransitions()
        {
            base.ConfigureMachineTransitions();
            machine.StateMachine.Configure(state)
                .Permit(MenuTrigger.BackToMain, MenuType.Main);
        }
    }
}