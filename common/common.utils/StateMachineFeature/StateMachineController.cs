using System;
using CST.Common.Utils.StateMachineFeature.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CST.Common.Utils.StateMachineFeature
{
    [Controller]
    public class StateMachineController<TKey> : ControllerBase 
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
        public IActionResult GetTransitions()
        {
            return Ok(_stateMachineMetaService.GetInitialTransitions());
        }

        [HttpGet("transitions/{currentStateId}")]
        public IActionResult GetTransitions(TKey currentStateId)
        {
            return Ok(_stateMachineMetaService.GetTransitions(currentStateId));
        }
    }
}