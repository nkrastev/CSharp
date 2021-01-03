namespace CustomDataStructures
{
    /// <summary>
    /// Node in Linked List
    /// </summary>
    public class ListNode
    {
        /// <summary>
        /// Pointer to next element
        /// </summary>
        public ListNode Next { get; set; }        
        /// <summary>
        /// Value of current Node
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Create new node
        /// </summary>
        /// <param name="value">The value for the node</param>
        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
