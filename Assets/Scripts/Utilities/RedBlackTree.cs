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
            Node target = Search(val);
            if (target == null)
                return;
            Remove(target);
        }

        private Node Search(T val)
        {
            Node curr = head;
            while (true)
            {
                if (curr.val.CompareTo(val) == 0)
                    return curr;
                else if(curr.val.CompareTo(val) > 0)
                {
                    if (curr.left == null)
                        return null;
                    curr = curr.left;
                }
                else
                {
                    if (curr.right == null)
                        return null;
                    curr = curr.right;
                }
            }
        }

        private Node Remove(Node node)
        {
            if(node.left == null && node.right == null)
            {
                Replace(node, null);
                return node;
            }
            else if(node.left != null)
            {
                Node left = node.left;
                while(left.right != null)
                {
                    left = left.right;
                }
                Remove(left);
                Replace(node, left);
                // Restore red-black property
            }
            else
            {
                Node right = node.right;
                while (right.left != null)
                {
                    right = right.left;
                }
                Remove(right);
                Replace(node, right);
                // Restore red-black property
            }
        }
        private void Replace(Node curr, Node replacer)
        {
            if (curr == curr.parent.left)
                curr.parent.left = replacer;
            else
                curr.parent.right = replacer;
            if(replacer != null)
            {
                replacer.parent = curr.parent;
                replacer.left = curr.left;
                if(curr.left != null)
                    curr.left.parent = replacer;
                replacer.right = curr.right;
                if(curr.right != null)
                    curr.right.parent = replacer;
            }
            
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
                    node = par.parent;
                    par = node.parent;
                }
                else // rotate and re-color
                {
                    par.parent.color = true;
                    if(par == par.left)
                    {
                        if(node == par.left)
                        {
                            RightRotate(par);                           
                        }
                        else
                        {
                            LeftRotate(node);
                            RightRotate(node);
                            node.color = false;
                        }
                    }
                    else
                    {
                        if (node == par.right)
                        {
                            LeftRotate(par);
                        }
                        else
                        {
                            RightRotate(node);
                            LeftRotate(node);
                            node.color = false;
                        }
                    }
                    break;
                }
            }
            if (par == null && node.color)
            {
                node.color = false;
            }
        }

        private void RightRotate(Node node)
        {
            Node par = node.parent;
            par.left = node.right;
            node.right = par;
            if (par.parent != null && par.parent.right == par)
                par.parent.right = node;
            else if (par.parent != null)
                par.parent.left = node;
            node.parent = par.parent;
            par.parent = node;
        }

        private void LeftRotate(Node node)
        {
            Node par = node.parent;
            par.right = node.left;
            node.left = par;
            if (par.parent != null && par.parent.right == par)
                par.parent.right = node;
            else if (par.parent != null)
                par.parent.left = node;
            node.parent = par.parent;
            par.parent = node;
        }
    }
}
