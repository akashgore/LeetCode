using LeetCode.Models;
using System.Collections.Generic;

namespace LeetCode.Logic
{
    public class TreeProblems
    {
        /**
        * ? 100: Same Tree
        * ! Algorithm: 
        * ! Notes:
        **/
        public bool IsSameTree(TreeNode p, TreeNode q) 
        {
            return true;
        }

        /**
        * ? 94: Binary Tree Inorder Traversal 
        * ! Algorithm: Use BFS and print node values
        * ! Notes:
        **/
        public IList<int> InorderTraversal(TreeNode root) 
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<int> result = new List<int>();
            q.Enqueue(root);

            while(q.Count!=0)
            {
                root = q.Dequeue();
                if (root.left!=null)
                {
                    q.Enqueue(root.left);
                    result.Add(root.left.val);

                }
                if (root.right!=null)
                {
                    q.Enqueue(root.right);
                    result.Add(root.right.val);
                }
            }
            return result;


        }

        /**
        * ? 572: Subtree of Another Tree
        * ! Algorithm:
        * ! Notes:
        **/
        public bool IsSubtree(TreeNode s, TreeNode t) 
        {

        }


    }
}