﻿using System;
using System.Collections.Generic;
using System.Linq;
using CST.Common.Utils.StateMachineFeature.Exceptions;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseStateMachineService<TKey, TGraphEnum, TVertexEnum, TSubject, TRepository>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
        where TRepository : BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected readonly TRepository Repository;

        protected BaseStateMachineService(TRepository repository)
        {
            Repository = repository;
        }

        // ReSharper disable once MemberCanBeProtected.Global
        public abstract TGraphEnum Graph { get; }
        protected abstract void PreInitializeSubject(TSubject subject);
        protected abstract void PostInitializeSubject(TSubject subject);

        protected abstract void PostInitializeSubjectState(
            StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject> subjectState);

        public TSubject InitializeSubject()
        {
            var rootVertex = Repository.GetRootVertex();
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
            var initialVertex = Repository.GetVertex(initialVertexEnum);
            subject.CurrentSubjectState =
                new StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject>
                {
                    Subject = subject,
                    Vertex = initialVertex
                };
            Repository.AddSubjectMoment(subject.CurrentSubjectState);
            PostInitializeSubject(subject);
            PostInitializeSubjectState(subject.CurrentSubjectState);
            return subject;
        }

        protected abstract void PreStepSubject(TSubject subject, TKey edgeId);
        protected abstract void PostStepSubject(TSubject subject, TKey edgeId);
        protected abstract void PostStepSubjectState(
            StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject> subjectState);

        // ReSharper disable once MemberCanBePrivate.Global
        public TSubject StepSubject(TSubject subject, TKey edgeId)
        {
            PreStepSubject(subject, edgeId);
            var currentVertex = subject.CurrentSubjectState.Vertex;
            var edge = EnsureEdge(currentVertex, edgeId);
            subject.CurrentSubjectState =
                new StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject>
                {
                    Subject = subject, 
                    Vertex = edge.Head
                };
            Repository.AddSubjectMoment(subject.CurrentSubjectState);
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

        private Edge<TKey, TGraphEnum, TVertexEnum> EnsureEdge(
            Vertex<TKey, TGraphEnum, TVertexEnum> vertex, 
            TKey edgeId)
        {
            var resultEdge = vertex.OutEdges.FirstOrDefault(edge => edge.Id.Equals(edgeId));
            if (resultEdge != null) return resultEdge;

            var erroringEdge = Repository.GetEdge(edgeId);
            if (erroringEdge == null)
            {
                throw new EdgeDoesNotExistException<TKey, TVertexEnum>(edgeId);
            }

            throw new VertexNotConnectedToEdgeException(vertex.Name, erroringEdge.Name);
        }
    }
}