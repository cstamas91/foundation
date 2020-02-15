using System;
using System.Collections.Generic;
using System.Linq;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.ViewModel;

namespace CST.Common.Utils.StateMachineFeature.ViewModel
{
    public class StateMachineMetaService<TKey, TGraphEnum, TVertexEnum, TRepository, TSubject> :
        IStateMachineMetaService<TKey>
        where TKey : struct, IEquatable<TKey>
        where TRepository : BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>
    {
        private readonly TRepository _repository;

        public StateMachineMetaService(TRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Selectable<TKey>> GetStates()
        {
            return _repository
                .GetVertices()
                .Select(Selectable<TKey>.Create);
        }

        public IEnumerable<Selectable<TKey>> GetInitialTransitions()
        {
            return _repository
                .GetRootVertex()
                .OutEdges
                .Select(Selectable<TKey>.Create);
        }

        public IEnumerable<Selectable<TKey>> GetTransitions(TKey currentStateId)
        {
            return _repository
                .GetVertex(currentStateId)
                .OutEdges
                .Select(Selectable<TKey>.Create);
        }
    }
}