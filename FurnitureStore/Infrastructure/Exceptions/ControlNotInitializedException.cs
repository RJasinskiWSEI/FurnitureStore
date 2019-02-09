using System;

namespace FurnitureStore.Infrastructure.Exceptions
{
    /// <summary>
    /// The exception that is thrown when there is and attempt to not initialized control.
    /// </summary>
    [Serializable]
    public class ControlNotInitializedException : Exception
    {
        public ControlNotInitializedException() { }
        public ControlNotInitializedException(string message) : base(message) { }
        public ControlNotInitializedException(string message, Exception inner) : base(message, inner) { }
        protected ControlNotInitializedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
