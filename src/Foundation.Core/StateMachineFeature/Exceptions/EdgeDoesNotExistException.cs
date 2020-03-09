using System;

namespace Foundation.Core.StateMachineFeature.Exceptions
{
    public class EdgeDoesNotExistException<TKey, TVertexEnum> : Exception 
        where TKey : IEquatable<TKey>
        where TVertexEnum : struct, IConvertible
    {
        private readonly TKey _key;
        private readonly TVertexEnum? _vertexEnum;

        public EdgeDoesNotExistException(TKey key)
        {
            _key = key;
            _vertexEnum = default;
        }

        public EdgeDoesNotExistException(TVertexEnum vertexEnum)
        {
            _vertexEnum = vertexEnum;
            _key = default;
        }
    }
}