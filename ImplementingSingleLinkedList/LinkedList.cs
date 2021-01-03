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
        /// <summary>
        /// Linked list count
        /// </summary>
        public LinkedList()
        {
            this.Count = 0;
        }
        /// <summary>
        /// Linked list loop
        /// </summary>
        /// <param name="collection"></param>
        public LinkedList(IEnumerable<int> collection)
            : this()
        {
            foreach (var value in collection)
            {
                this.AddLast(value);
            }
        }
        /// <summary>
        /// Adding element at the end
        /// </summary>
        /// <param name="value"></param>
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
        /// <summary>
        /// Adding element at the begining
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(int value)
        {
            var newElement = new ListNode(value);
            if (First == null)
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
        /// <summary>
        /// Searching for element
        /// </summary>
        /// <param name="value">Searched value</param>
        /// <returns></returns>
        public ListNode Find(int value)
        {
            ListNode result = null;
            var current = First;
            while (current!=null)
            {
                if (current.Value==value)
                {
                    result = current;
                    break;
                }
                current = current.Next;
            }
            return result;

        }

        /// <summary>
        /// List Loop
        /// </summary>
        /// <returns></returns>
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
