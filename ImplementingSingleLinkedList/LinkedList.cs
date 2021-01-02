using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    /// <summary>
    /// Linked list of Integers
    /// </summary>
    public class LinkedList
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
    }
}
