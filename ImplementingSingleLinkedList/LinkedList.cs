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
        /// Adding element after specific one
        /// </summary>
        /// <param name="node">Element to be added after</param>
        /// <param name="value">Value to be added</param>
        public void AddAfter(ListNode node, int value)
        {
            if (node==null)
            {
                throw new ArgumentNullException("Node cannot be empty");
            }

            var newElement = new ListNode(value);
            newElement.Next = node.Next;
            node.Next = newElement;
            Count++;
        }
        /// <summary>
        /// Adding before node
        /// </summary>
        /// <param name="node">Node to add before</param>
        /// <param name="value">Value to be added</param>
        public void AddBefore(ListNode node, int value)
        {
            if (node==null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            var newElement = new ListNode(value);

            if (node==First)
            {
                newElement.Next = First;
                First = newElement;
            }
            else
            {
                var current = First;
                while (current!=null)
                {
                    if (current.Next==node)
                    {
                        newElement.Next = node;
                        current.Next = newElement;
                        break;
                    } 
                }
            }
            Count++;

        }
        /// <summary>
        /// Removing Node
        /// </summary>
        /// <param name="node"></param>
        public void Remove(ListNode node)
        {
            if (node==null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            if (First==node)
            {
                First = First.Next;
            }
            else
            {
                var current = First;
                while (current!=null)
                {
                    if (current.Next==node)
                    {
                        current.Next = node.Next;
                        break;
                    }
                }
                current = current.Next;
            }
            Count--;
        }
        /// <summary>
        /// Removing by value
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            var node = Find(value);

            if (node!=null)
            {
                Remove(node);
            }
        }
        /// <summary>
        /// Removing First element
        /// </summary>
        public void RemoveFirst()
        {
            if (First!=null)
            {
                if (First==Last)
                {
                    Last = null;
                }
                First = First.Next;
            }
        }
        /// <summary>
        /// Remove last element of the collection
        /// </summary>
        public void RemoveLast()
        {
            if (Last!=null)
            {
                if (Last==First)
                {
                    Last = First = null;
                }
                var current = First;
                while (current!=null)
                {
                    if (current.Next==Last)
                    {
                        current.Next = null;
                    }

                    current = current.Next;
                }
            }
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
