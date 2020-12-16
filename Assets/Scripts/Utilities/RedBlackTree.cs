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
                // handle deletion
                if(node == head)
                {
                    head = null;
                    return head;
                }
                if (node.color)
                    HoistNull(node);
                else
                    FixDoubleBlack(node);
            }
            else if(node.left != null)
            {
                Node left = node.left;
                while(left.right != null)
                {
                    left = left.right;
                }
                T temp = node.val;
                node.val = left.val;
                left.val = temp;
                Remove(left);
            }
            else
            {
                Node right = node.right;
                while (right.left != null)
                {
                    right = right.left;
                }
                T temp = node.val;
                node.val = right.val;
                right.val = temp;
                Remove(right);
            }
        }

        private void FixDoubleBlack(Node node)
        {
            if (node == head)
                return;
            Node sib = GetSibling(node);
            if (sib == null)
                FixDoubleBlack(node.parent);
            else
            {
                if (sib.color)
                {
                    sib.color = false;
                    sib.parent.color = true;
                    if (sib == sib.parent.left)
                        RightRotate(sib);
                    else
                        LeftRotate(sib);
                    FixDoubleBlack(node);
                }
                else
                {
                    if(sib.left != null && sib.left.color)
                    {
                        if (sib == sib.parent.left)
                        {
                            sib.left.color = sib.color;
                            sib.color = sib.parent.color;
                            RightRotate(sib);
                        }
                        else
                        {
                            sib.left.color = sib.right.color;
                            Node child = sib.left;
                            RightRotate(child);
                            LeftRotate(child);
                        }
                        node.parent.color = false;
                    }
                    else if(sib.right != null && sib.right.color)
                    {
                        sib.right.color = false;
                        if (sib == sib.parent.right)
                        {
                            sib.right.color = sib.color;
                            sib.color = sib.parent.color;
                            LeftRotate(sib);
                        }
                        else
                        {
                            sib.right.color = sib.parent.color;
                            Node child = sib.left;
                            LeftRotate(child);
                            RightRotate(child);
                        }
                        node.parent.color = false;
                    }
                    else
                    {
                        sib.color = true;
                        if (node.parent.color)
                            node.parent.color = false;
                        else
                            FixDoubleBlack(node.parent);
                    }
                }
            }
            if (node.left == null && node.right == null)
                HoistNull(node);
        }

        private void HoistNull(Node node)
        {
            if (node == node.parent.left)
                node.parent.left = null;
            else
                node.parent.right = null;
        }

        private Node GetSibling(Node node)
        {
            if (node == node.parent.left)
                return node.parent.right;
            else
                return node.parent.left;
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
