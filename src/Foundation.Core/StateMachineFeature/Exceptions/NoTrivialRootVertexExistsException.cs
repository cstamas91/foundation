﻿using System;

namespace Foundation.Core.StateMachineFeature.Exceptions
{
    public class NoTrivialRootVertexExists<TGraphEnum> : Exception
        where TGraphEnum : struct, IConvertible
    {
        private readonly TGraphEnum _graphEnum;

        public NoTrivialRootVertexExists(TGraphEnum graphEnum)
        {
            _graphEnum = graphEnum;
        }
    }
}