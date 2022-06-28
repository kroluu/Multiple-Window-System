using UI.MachineManagers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class MenuStateSwitchButton : Button
{
    [SerializeField] private MenuTrigger trigger;
    [Inject] private UIMenuMachine menuMachine;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        menuMachine.StateMachine.Fire(trigger);
    }

}
