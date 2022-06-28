using System;
using Stateless;
using UnityEngine;

namespace UI.MachineManagers
{
    /// <summary>
    /// Generic abstract class <c>UIMachine</c> that manages changing states in scene 
    /// </summary>
    /// <typeparam name="TState">Generic parameter of enum type that defines states in state machine. Each machine has it's own enum states</typeparam>
    /// <typeparam name="TTrigger">Generic parameter of enum type that defines triggers in state machine. Each machine has it's own enum states</typeparam>
    public abstract class UIMachine<TState,TTrigger> : MonoBehaviour where TState: Enum where TTrigger: Enum
    {
        /// <summary>
        /// State machine that holds UI states and their triggers
        /// </summary>
        public readonly StateMachine<TState, TTrigger> StateMachine = new StateMachine<TState, TTrigger>(default);
        
        public State<TState,TTrigger> currentState;
    
        /// <summary>
        /// Event holding methods that checks if changed state applies to it's state 
        /// </summary>
        public event Action<TState> OnChangeState;

        public Canvas Canvas { get; private set; }

        private void Awake()
        {
            AssignComponents();
        }

        private void AssignComponents()
        {
            Canvas = GetComponent<Canvas>();
        }

        /// <summary>
        /// Invokes all methods subscribed to event
        /// </summary>
        /// <param name="_stateToSet"></param>
        public void OnChangeMachineState(TState _stateToSet)
        {
            OnChangeState?.Invoke(_stateToSet);
        }

        protected virtual void Update()
        {
            if (currentState is {})
            {
                currentState.DoActions();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentState.ExecuteEscapeBehaviour();
            }
        }
    }
}