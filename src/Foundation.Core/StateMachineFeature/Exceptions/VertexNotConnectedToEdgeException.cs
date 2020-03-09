using System;

namespace Foundation.Core.StateMachineFeature.Exceptions
{
    public class VertexNotConnectedToEdgeException : Exception
    {
        private readonly string _vertexName;
        private readonly string _edgeName;

        public VertexNotConnectedToEdgeException(string vertexName, string edgeName)
        {
            _vertexName = vertexName;
            _edgeName = edgeName;
        }
    }
}