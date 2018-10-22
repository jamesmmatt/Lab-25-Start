/* BinaryTreeNode.cs
 * Author: Rod Howell */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    /// <summary>
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public partial class LeftistTree<T> : ITree
    {
        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T> LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T> RightChild { get; }

        private int _pathLength = 0;

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public LeftistTree(T data, LeftistTree<T> left, LeftistTree<T> right)
        {
            Data = data;
            if (NullPathLength(left) < NullPathLength(right))
            {
                LeftChild = right;
                RightChild = left;
            }
            else
            {
                LeftChild = left;
                RightChild = right;
            }
            _pathLength = 1 + NullPathLength(RightChild);            
        }

        /// <summary>
        /// Gets the length
        /// </summary>
        /// <param name="t">t is the tree</param>
        /// <returns>returns the legnth</returns>
        public static int NullPathLength(LeftistTree<T> t)
        {
            if(t == null || t._pathLength == 0)
            {
                return 0;
            }
            else
            {
                return t._pathLength;
            }
        }
    }
}
