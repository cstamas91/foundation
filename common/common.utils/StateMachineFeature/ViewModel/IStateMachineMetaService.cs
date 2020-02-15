﻿using System;
using System.Collections;
using System.Collections.Generic;
using CST.Common.Utils.ViewModel;

namespace CST.Common.Utils.StateMachineFeature.ViewModel
{
    public interface IStateMachineMetaService<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<Selectable<TKey>> GetStates();
        IEnumerable<Selectable<TKey>> GetInitialTransitions();
        IEnumerable<Selectable<TKey>> GetTransitions(TKey currentStateId);
    }
}