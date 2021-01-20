using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public class RedBlackTree<T> where T : IComparable
    {
        public class Node
        {
            public T val;
            public Node left;
            public Node right;
            public Node parent;
            public bool color;
            public Node next, previous;
            public Node(T val, bool color)

            {
                this.val = val;
                this.color = color;
                left = null;
                right = null;
                parent = null;
            }
        }

        public Node head { get; set; }
        public RedBlackTree()
        {
            head = null;
        }

        public Node Insert(T val)
        {
            if (val == null)
                return null;
            if(head == null)
            {
                head = new Node(val, false);
                return head;
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
            return curr;
        }

        public Node Remove(T val)
        {
            if (val == null)
                return null;
            Node target = Search(val);
            if (target == null)
                return null;
            Remove(target);
            return target;
        }

        public Node Search(T val)
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

        public T[] InOrderTraversal()
        {
            List<T> ar = new List<T>();
            InOrderHelper(ar, this.head);
        }

        private void InOrderHelper(List<T> ar, Node node)
        {
            if(node.left != null)
            {
                InOrderHelper(ar, node.left);
            }
            ar.Add(node.val);
            if(node.right != null)
            {
                InOrderHelper(ar, node.right);
            }
        }

        private void Remove(Node node)
        {
            if(node.left == null && node.right == null)
            {
                // handle deletion
                if(node == head)
                {
                    head = null;
                    return;
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
            if (node == null)
                return;
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
                            par.color = false;
                            RightRotate(par);                           
                        }
                        else
                        {
                            node.color = false;
                            LeftRotate(node);
                            RightRotate(node);
                        }
                    }
                    else
                    {
                        if (node == par.right)
                        {
                            par.color = false;
                            LeftRotate(par);
                        }
                        else
                        {
                            node.color = false;
                            RightRotate(node);
                            LeftRotate(node);
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
