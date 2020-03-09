using System;
using Foundation.StateMachineFeature.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.StateMachineFeature
{
    [Controller]
    public class StateMachineController<TKey, TSubject> : ControllerBase 
        where TKey : struct, IEquatable<TKey>
    {
        private readonly IStateMachineMetaService<TKey> _stateMachineMetaService;

        public StateMachineController(IStateMachineMetaService<TKey> stateMachineMetaService)
        {
            _stateMachineMetaService = stateMachineMetaService;
        }
        
        [HttpGet("states")]
        public IActionResult GetStates()
        {
            return Ok(_stateMachineMetaService.GetStates());
        }

        [HttpGet("transitions")]
        public IActionResult GetTransitions([FromQuery] TKey? currentStateId)
        {
            return Ok(currentStateId.HasValue 
                ? _stateMachineMetaService.GetTransitionsFromState(currentStateId.Value) 
                : _stateMachineMetaService.GetInitialTransitions());
        }
    }
}