using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree
    {
        #region Is balanced
        bool balanced = true;
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            IsBalancedHelper(root);

            return balanced;
        }
        private int IsBalancedHelper(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int lHeight = IsBalancedHelper(root.left) + 1;
            int rHeight = IsBalancedHelper(root.right) + 1;

            int max = Math.Max(lHeight, rHeight);
            int min = Math.Min(lHeight, rHeight);

            if (max - min > 1)
            {
                balanced = false;
            }

            return max;
        }

        #endregion

        #region BFS tree with level
        public void BFSTreeWithLevel(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            q.Enqueue(root);
            int level = 0;

            while (q.Any() || q1.Any())
            {
                TreeNode cur;
                while (q.Any())
                {
                    cur = q.Dequeue();
                    Console.WriteLine(cur.val);
                    if (cur.left != null)
                    {
                        q1.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        q1.Enqueue(cur.right);
                    }

                }
                Console.WriteLine("--------------");
                while (q1.Any())
                {
                    cur = q1.Dequeue();
                    Console.WriteLine(cur.val);
                    if (cur.left != null)
                    {
                        q.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        q.Enqueue(cur.right);
                    }
                }
                Console.WriteLine("--------------");
            }
        }
        #endregion

        #region Connect nodes
        public void connect(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);
            //level traverse 
            while (q.Any())
            {
                int count = q.Count;
                while (count > 0)
                {
                    TreeNode temp = q.Dequeue();
                    if (count == 1)
                    {
                        //root.next = null;
                    }
                    else
                    {
                        //root.left.next = q.Peek();
                    }

                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);
                    }

                    count--;
                }

            }
        }
        #endregion

        #region PostOrderTraverse
        public List<int> PostOrderTraverse(TreeNode root)
        {
            LinkedList<int> list = new LinkedList<int>();
            if (root == null)
            {
                return list.ToList();
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                TreeNode cur = stack.Pop();
                list.AddFirst(cur.val);

                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }
                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }
            }

            return list.ToList();
        }
        #endregion

        #region LCA lowest common ancestor
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || q == null || p == null)
            {
                return null;
            }

            //right subtree
            if (Math.Min(p.val, q.val) > root.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            //left subtree
            else if (Math.Max(p.val, q.val) < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else
            {
                return root;
            }
        }
        #endregion
    }
}
