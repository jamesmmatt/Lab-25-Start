/*MinPriorityQueue.cs
 * Author: Matthew James
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    public class MinPriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// A leftist heap storing the elements and their priorities.
        /// </summary>
        private LeftistTree<KeyValuePair<TPriority, TValue>> _elements = null;

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds the given element with the given priority.
        /// </summary>
        /// <param name="p">The priority of the element.</param>
        /// <param name="x">The element to add.</param>
        public void Add(TPriority p, TValue x)
        {
            LeftistTree<KeyValuePair<TPriority, TValue>> node =
                new LeftistTree<KeyValuePair<TPriority, TValue>>(new KeyValuePair<TPriority, TValue>(p, x), null, null);
            _elements = Merge(_elements, node);
            Count++;
        }

        /// <summary>
        /// Gets the minimum priority
        /// </summary>
        public TPriority MinimumPriority
        {
            get
            {
                if(_elements == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _elements.Data.Key;
                }
            }
        }

        /// <summary>
        /// Merges the given leftist heaps into one leftist heap.
        /// </summary>
        /// <param name="h1">One of the leftist heaps to merge.</param>
        /// <param name="h2">The other leftist heap to merge.</param>
        /// <returns>The resulting leftist heap.</returns>
        public static LeftistTree<KeyValuePair<TPriority, TValue>> Merge(LeftistTree<KeyValuePair<TPriority, TValue>> h1,
            LeftistTree<KeyValuePair<TPriority, TValue>> h2)
        {
            if (h2 == null)
            {
                return h1;
            }
            else if(h1 == null)
            {
                return h2;
            }
            else
            {
                int compare = h1.Data.Key.CompareTo(h2.Data.Key);
                if(compare < 0)
                {

                    LeftistTree<KeyValuePair<TPriority, TValue>> rightTree = Merge(h1.RightChild, h2);
                    return new LeftistTree<KeyValuePair<TPriority, TValue>>(h1.Data, h1.LeftChild, rightTree);
                }
                else
                {
                    LeftistTree<KeyValuePair<TPriority, TValue>> rightTree = Merge(h2.RightChild, h1);
                    return new LeftistTree<KeyValuePair<TPriority, TValue>>(h2.Data, h2.LeftChild, rightTree);
                }
            }
        }

        /// <summary>
        /// removes the element with min priority and returns that element
        /// </summary>
        /// <returns></returns>
        public TValue RemoveMinimumPriority()
        {
            if (_elements != null)
            {
                TValue value = _elements.Data.Value;
                _elements = Merge(_elements.LeftChild, _elements.RightChild);
                Count--;
                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
