using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    internal class RedBlackTree<T> where T : IComparable
    {
        private class Node
        {
            public T val { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public Node parent { get; set; }
            public bool color { get; set; }
            public Node(T val, bool color)
            {
                this.val = val;
                this.color = color;
                left = null;
                right = null;
                parent = null;
            }
        }

        private Node head { get; set; }
        RedBlackTree()
        {
            head = null;
        }

        void Insert(T val)
        {
           if(head == null)
            {
                head = new Node(val, false);
                return;
            }
            Node curr = head;
            while(curr != null)
            {
                if(curr.val.CompareTo(val) >= 0 && curr.left == null)
                {
                    curr.left = new Node(val, true);
                    curr.left.parent = curr;
                    curr = curr.left;
                    break;
                }
                else if(curr.val.CompareTo(val) >= 0)
                {
                    curr = curr.left;
                }
                else if (curr.val.CompareTo(val) < 0 && curr.right == null)
                {
                    curr.right = new Node(val, true);
                    curr.right.parent = curr;
                    curr = curr.right;
                    break;
                }
                else
                {
                    curr = curr.right;
                }
            }
            // Rebalance Tree if necessary
            Rebalance(curr);
        }

        void Remove(T val)
        {

        }

        void Rebalance(Node node)
        {
            Node par = node.parent;
            while(par != null && par.color)
            {
                Node uncle = par == par.parent.left ? par.parent.right : par.parent.left;
                if (uncle.color) // re-color only
                {
                    par.color = false;
                    uncle.color = false;
                    par.parent.color = true;
                }
                else // rotate and re-color
                {

                }
                node = par;
                par = node.parent;
            }
            if (par == null && node.color)
            {
                node.color = false;
            }
        }
    }
}
