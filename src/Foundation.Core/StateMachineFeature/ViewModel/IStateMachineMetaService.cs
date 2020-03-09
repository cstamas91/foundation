using System;
using System.Collections.Generic;
using Foundation.Core.ViewModel;

namespace Foundation.Core.StateMachineFeature.ViewModel
{
    public interface IStateMachineMetaService<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<Selectable<TKey>> GetStates();
        IEnumerable<Selectable<TKey>> GetInitialTransitions();
        IEnumerable<Selectable<TKey>> GetTransitionsFromState(TKey currentStateId);
        IEnumerable<Selectable<TKey>> GetTransitionsForSubject(TKey subjectId);
    }
}