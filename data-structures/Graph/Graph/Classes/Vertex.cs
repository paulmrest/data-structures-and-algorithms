using System;

namespace Graph
{
    public class Vertex<T>
    {
        public T Value { get; set; }

        /// <summary>
        /// Instantiates a new Vertex object with T value.
        /// </summary>
        /// <param name="value"></param>
        public Vertex(T value)
        {
            Value = value;
        }
    }
}
