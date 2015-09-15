using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = CreateTree();
            BinaryTree tree = new BinaryTree();

            tree.BFSTreeWithLevel(root);
            Console.ReadLine();
        }

        public static TreeNode CreateTree()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            return ConstructBinaryTreeWithArray(arr, 0, arr.Length - 1);
        }

        private static TreeNode ConstructBinaryTreeWithArray(int[] arr, int l, int r)
        {
            if (l > r)
            {
                return null;
            }

            int mid = (l + r) / 2;
            TreeNode root = new TreeNode(arr[mid]);
            root.left = ConstructBinaryTreeWithArray(arr, l, mid - 1);
            root.right = ConstructBinaryTreeWithArray(arr, mid + 1, r);
            return root;

        }
    }
}
