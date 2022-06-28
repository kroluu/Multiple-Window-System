namespace UI.MachineManagers.MenuStates
{
    public class MenuLoadState : MenuState
    {
        protected override void Awake()
        {
            state = MenuType.Load;
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