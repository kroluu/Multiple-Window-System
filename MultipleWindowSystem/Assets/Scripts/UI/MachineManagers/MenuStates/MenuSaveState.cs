namespace UI.MachineManagers.MenuStates
{
    public class MenuSaveState : MenuState
    {
        protected override void Awake()
        {
            state = MenuType.Save;
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