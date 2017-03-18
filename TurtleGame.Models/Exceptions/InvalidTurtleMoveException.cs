using System;

namespace TurtleGame.Exceptions
{
    public class InvalidTurtleMoveException : Exception
    {
        public InvalidTurtleMoveException()
        {
        }

        public InvalidTurtleMoveException(string message)
        : base(message)
        {
        }

        public InvalidTurtleMoveException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
