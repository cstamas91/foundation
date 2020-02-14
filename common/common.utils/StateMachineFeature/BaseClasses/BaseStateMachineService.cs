using System;
using System.Collections.Generic;
using System.Linq;
using CST.Common.Utils.StateMachineFeature.Abstraction;
using CST.Common.Utils.StateMachineFeature.Exceptions;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseStateMachineService<TGraphEnum, 
                                                  TVertexEnum,
                                                  TSubject, 
                                                  TVertex, 
                                                  TSubjectState, 
                                                  TEdge, 
                                                  TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : ISubject<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>, new()
        where TSubjectState : ISubjectState<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>, new()
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
        where TKey : IEquatable<TKey>
    {
        private readonly BaseStateMachineRepository<TGraphEnum, 
                                                    TVertexEnum, 
                                                    TSubject, 
                                                    TSubjectState, 
                                                    TVertex, 
                                                    TEdge,
                                                    TKey> _repository;
        
        protected BaseStateMachineService(BaseStateMachineRepository<TGraphEnum, 
                                                                     TVertexEnum, 
                                                                     TSubject, 
                                                                     TSubjectState, 
                                                                     TVertex, 
                                                                     TEdge, 
                                                                     TKey> repository)
        {
            _repository = repository;
        }
        
        // ReSharper disable once MemberCanBeProtected.Global
        public abstract TGraphEnum Graph { get; }
        protected abstract void PreInitializeSubject(TSubject subject);
        protected abstract void PostInitializeSubject(TSubject subject);
        protected abstract void PostInitializeSubjectState(TSubjectState subjectState);

        public TSubject InitializeSubject()
        {
            var rootVertex = _repository.GetRootVertex();
            if (rootVertex == null)
            {
                throw new NoTrivialRootVertexExists<TGraphEnum>(Graph);
            }
            return InitializeSubject(rootVertex.VertexEnum);
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public TSubject InitializeSubject(TVertexEnum initialVertexEnum)
        {
            return InitializeSubject(new TSubject(), initialVertexEnum);
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public TSubject InitializeSubject(TSubject subject, TVertexEnum initialVertexEnum)
        {
            PreInitializeSubject(subject);
            var initialVertex = _repository.GetVertex(initialVertexEnum);
            subject.CurrentSubjectState = new TSubjectState {Subject = subject, Vertex = initialVertex};
            _repository.AddSubjectState(subject.CurrentSubjectState);
            PostInitializeSubject(subject);
            PostInitializeSubjectState(subject.CurrentSubjectState);
            return subject;
        }

        protected abstract void PreStepSubject(TSubject subject, TKey edgeId);
        protected abstract void PostStepSubject(TSubject subject, TKey edgeId);
        protected abstract void PostStepSubjectState(TSubjectState subjectState);
        // ReSharper disable once MemberCanBePrivate.Global
        public TSubject StepSubject(TSubject subject, TKey edgeId)
        {
            PreStepSubject(subject, edgeId);
            var currentVertex = subject.CurrentSubjectState.Vertex;
            var edge = EnsureEdge(currentVertex, edgeId);
            subject.CurrentSubjectState = new TSubjectState{Subject = subject, Vertex = edge.Head};
            _repository.AddSubjectState(subject.CurrentSubjectState);
            PostStepSubject(subject, edgeId);
            PostStepSubjectState(subject.CurrentSubjectState);
            return subject;
        }

        public TSubject StepSubject(TSubject subject, TVertexEnum targetVertexEnum)
        {
            var edgeIds = subject.CurrentSubjectState
                .Vertex
                .OutEdges
                .Where(edge => edge.Head.VertexEnum.Equals(targetVertexEnum))
                .Select(edge => edge.Id)
                .ToList();

            if (edgeIds.Count != 1)
            {
                throw new EdgeDoesNotExistException<TKey, TVertexEnum>(targetVertexEnum);
            }

            return StepSubject(subject, edgeIds[0]);
        }

        private TEdge EnsureEdge(TVertex vertex, TKey edgeId)
        {
            var resultEdge = vertex.OutEdges.FirstOrDefault(edge => edge.Id.Equals(edgeId));
            if (resultEdge != null) return resultEdge;
            
            var erroringEdge = _repository.GetEdge(edgeId);
            if (erroringEdge == null)
            {
                throw new EdgeDoesNotExistException<TKey, TVertexEnum>(edgeId);
            }
                
            throw new VertexNotConnectedToEdgeException(vertex.Name, erroringEdge.Name);
        }
    }
}