using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Utilities;
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
        public void Insert_Black_Parent_Red_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Insert_Black_Parent_Black_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Insert_Red_Parent_Red_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Insert_Red_Parent_Black_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

        }

        [TestMethod]
        public void Insert_Null_Uncle()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

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
