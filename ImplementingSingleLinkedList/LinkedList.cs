using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    /// <summary>
    /// Linked list of Integers
    /// </summary>
    public class LinkedList : IEnumerable<int>
    {
        /// <summary>
        /// First Node of the Linked List
        /// </summary>
        public ListNode First { get; set; }
        /// <summary>
        /// Last Node of the Linked List
        /// </summary>
        public ListNode Last { get; set; }
        /// <summary>
        /// Number of nodes in the List
        /// </summary>
        public int Count { get; private set; }

        public LinkedList()
        {
            this.Count = 0;
        }
        public LinkedList(IEnumerable<int> collection)
            :this()
        {
            foreach (var value in collection)
            {
                this.AddLast(value);
            }
        }

        public void AddLast(int value)
        {
            var newElement = new ListNode(value);
            if (Last == null)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                Last.Next = newElement;
                Last = newElement;
            }
            Count++;
        }
        public void AddFirst(int value)
        {
            var newElement = new ListNode(value);
            if (First==null)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                newElement.Next = First;
                First = newElement;
            }
            Count++;
        }

        public IEnumerator<int> GetEnumerator()
        {
            ListNode current = First;
            while (current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
