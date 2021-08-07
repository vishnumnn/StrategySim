using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class RedBlackTree_Tests
    {
        // INSERTION TESTS
        [TestMethod]
        public void Insert_Into_Empty()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            int expected = 0;
            tree.Insert(expected);
            Assert.IsTrue(tree.head.val == expected);
        }

        [TestMethod]
        public void Insert_Black_Parent()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            List<Tuple<int, bool>> expected = new List<Tuple<int, bool>> { new Tuple<int, bool>(5, false) };
            tree.Insert(5);
            List<Tuple<int, bool>> actual = tree.PreOrderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_Red_Parent_Red_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            List<Tuple<int, bool>> expected = new List<Tuple<int, bool>>{ new Tuple<int, bool>(5,false), new Tuple<int, bool>(4,false), new Tuple<int, bool>(7,false),
                new Tuple<int, bool>(6, true) };
            tree.Insert(5); tree.Insert(4); tree.Insert(7); tree.Insert(6);
            List<Tuple<int, bool>> actual = tree.PreOrderTraversal();
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Insert_Null_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            List<Tuple<int, bool>> expected = new List<Tuple<int, bool>>{ new Tuple<int, bool>(5,false), new Tuple<int, bool>(4,false), new Tuple<int, bool>(7,false),
                new Tuple<int, bool>(6, true), new Tuple<int, bool>(8, true) };
            tree.Insert(5); tree.Insert(4); tree.Insert(8); tree.Insert(7); tree.Insert(6);
            List<Tuple<int, bool>> actual = tree.PreOrderTraversal();
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Insert_Red_Parent_Red_Uncle_Recolor_Grandparent()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            List<Tuple<int, bool>> expected = new List<Tuple<int, bool>>{ new Tuple<int, bool>(5,false), new Tuple<int, bool>(4,false), new Tuple<int, bool>(8,true),
                new Tuple<int, bool>(7, false), new Tuple<int, bool>(6, true),  new Tuple<int, bool>(9, false)};
            tree.Insert(5); tree.Insert(4); tree.Insert(8); tree.Insert(7); tree.Insert(9); tree.Insert(6);
            List<Tuple<int, bool>> actual = tree.PreOrderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_Black_Uncle_Red_Parent_On_Root()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();
            List<Tuple<int, bool>> expected = new List<Tuple<int, bool>>{ new Tuple<int, bool>(8,false), new Tuple<int, bool>(5,true), new Tuple<int, bool>(10,true)};
            tree.Insert(5); tree.Insert(8); tree.Insert(10);
            List<Tuple<int, bool>> actual = tree.PreOrderTraversal();
            CollectionAssert.AreEqual(expected, actual);
        }

        // DELETION TESTS
        [TestMethod]
        public void Delete_Into_Empty()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Black_GP_Red_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Red_GP_Black_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Black_GP_Black_Uncle_Null_Cousin_Red_Cousin()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Black_GP_Black_Uncle_Two_Red_Cousin()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Black_GP_Black_Uncle_Red_Cousin_Black_Cousin()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Black_GP_Black_Uncle_Black_Cousins()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Red_Node()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Delete_Double_Black_To_Root()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }
    }
}
