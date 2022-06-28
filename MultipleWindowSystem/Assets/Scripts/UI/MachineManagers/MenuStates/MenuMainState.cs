namespace UI.MachineManagers.MenuStates
{
    public class MenuMainState : MenuState
    {
        protected override void Awake()
        {
            machine.currentState = this;
            state = MenuType.Main;
            base.Awake();
        }
        
        protected override void ConfigureMachineTransitions()
        {
            base.ConfigureMachineTransitions();
            machine.StateMachine.Configure(state)
                .Permit(MenuTrigger.ToLoad, MenuType.Load)
                .Permit(MenuTrigger.ToSave, MenuType.Save)
                .Permit(MenuTrigger.ToOptions, MenuType.Options)
                .Permit(MenuTrigger.ToChooseLevel, MenuType.ChooseLevel)
                .Permit(MenuTrigger.ToExit, MenuType.Quit);
        }
    }
}
