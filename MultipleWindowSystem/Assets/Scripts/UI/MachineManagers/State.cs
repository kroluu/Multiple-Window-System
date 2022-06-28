using System;
using Core.Settings;
using DG.Tweening;
using UnityEngine;

namespace UI.MachineManagers
{
    /// <summary>
    /// Generic abstract class <c>State</c> is representation of specific state in scene
    /// </summary>
    /// <typeparam name="TState">Generic parameter of enum type that defines state types. Each states representation has it's own state types depends on current scene</typeparam>
    /// <typeparam name="TTrigger">Generic parameter of enum type that defines state triggers. Each triggers representation has it's own trigger types depends on current scene</typeparam>
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class State<TState,TTrigger> : MonoBehaviour where TState: Enum where TTrigger: Enum
    {
        /// <summary>
        /// State type
        /// </summary>
        protected TState state;
    
        /// <summary>
        /// State type getter
        /// </summary>
        public TState StateType => state;
    
        /// <summary>
        /// Machine reference currently on scene
        /// </summary>
        protected UIMachine<TState, TTrigger> machine;

        /// <summary>
        /// Canvas group for state visibility
        /// </summary>
        private CanvasGroup canvasGroup;
    
        protected virtual void Awake()
        {
            machine.OnChangeState += SetState;
            ConfigureMachineTransitions();
            GetComponents();
        }

        protected void Start()
        {
            VisibilityValidation();
        }

        /// <summary>
        /// Hides state if machine does not apply to its own representation
        /// </summary>
        private void VisibilityValidation()
        {
            if(machine.currentState.StateType.Equals(state)) return;
            HideView(true);
        }

        /// <summary>
        /// Gets components from objects
        /// </summary>
        protected virtual void GetComponents()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnDestroy()
        {
            machine.OnChangeState -= SetState;
        }

        /// <summary>
        /// Configure machine transitions for its own representation
        /// </summary>
        protected virtual void ConfigureMachineTransitions()
        {
            machine.StateMachine.Configure(state)
                .OnEntry(() =>
                {
                    machine.OnChangeMachineState(state);
                    AppearView();
                })
                .OnExit(() =>
                {
                    HideView();
                });
        }

        /// <summary>
        /// Alternative to MonoBehaviour <c>Update</c>. Called when state is set in machine.
        /// </summary>
        public virtual void DoActions()
        {
        
        }

        /// <summary>
        /// Called when <c>Escape</c> key was pressed
        /// </summary>
        public virtual void ExecuteEscapeBehaviour()
        {
        
        }

        protected abstract void SetState(TState _actualMachineState);

        /// <summary>
        /// Appears state representation on UI
        /// </summary>
        /// <param name="_instantShow">Appears state instantly</param>
        protected virtual void AppearView(bool _instantShow = false)
        {
            canvasGroup.DOFade(1f, _instantShow ? 0f: Config.TIME_FOR_PANEL_APPEARANCE).OnComplete(() =>
            {
                canvasGroup.blocksRaycasts = true;
            });
        }

        /// <summary>
        /// Hides state on UI
        /// </summary>
        /// <param name="_instantShow">Hides state instantly</param>
        protected virtual void HideView(bool _instantShow = false)
        {
            canvasGroup.DOFade(0f, _instantShow ? 0f: Config.TIME_FOR_PANEL_HIDE).OnComplete(() =>
            {
                canvasGroup.blocksRaycasts = false;
            });
        }

    }
}