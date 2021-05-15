namespace RepositoryPatternDemo.Common.ExceptionHandling
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Provides detail about customer exception.
    /// </summary>
    [Serializable]
    public class CustomException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomException() { }

        /// <summary>
        /// Sets message with parameterized constructor.
        /// </summary>
        /// <param name="message">Message</param>
        public CustomException(string message) : base(message) { }

        /// <summary>
        /// Sets message, inner exception in parameterized constructor.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="inner">Inner exception</param>
        public CustomException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Sets serialization info and streaming context in parameterized constructor.
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        protected CustomException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}
