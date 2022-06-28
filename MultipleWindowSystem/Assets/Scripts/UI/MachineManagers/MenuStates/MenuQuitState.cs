namespace UI.MachineManagers.MenuStates
{
    public class MenuQuitState : MenuState
    {
        protected override void Awake()
        {
            state = MenuType.Quit;
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
