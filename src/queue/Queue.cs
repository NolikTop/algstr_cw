using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using src.graph;

namespace src.queue
{
    public class Queue<T> : list.LinkedList<T>
    {
        public T Dequeue()
        {
            if (FirstElement is null)
            {
                throw new NullReferenceException("Queue is empty");
            }
            
            var first = FirstElement;

            FirstElement = first.Next;
            
            return first.Value;
        }

        public void Enqueue(T value)
        {
            Add(value);
        }

        public T Peek()
        {
            return First;
        }
    }
}