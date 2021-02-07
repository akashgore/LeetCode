using LeetCode.Models;
using System.Collections.Generic;

namespace LeetCode.Logic
{
    public class TreeProblems
    {
        /**
        * ? 94: Binary Tree Inorder Traversal 
        * ! Algorithm: Recursive -> InOrder(Left SubTree); print(Root); InOrder(Right SubTree)
        * ! Notes: 
             1. Inorder traversal on BST gives nodes in ascending order (flattens tree to the way it was constructed).
             2. Non-primitives are passed by reference & primitives are passed by value.
        **/
        public IList<int> InorderTraversal(TreeNode root) 
        {
            var result = new List<int>();
            InorderTraversalHelper(root, result);
            return result;
        }

        public void InorderTraversalHelper(TreeNode root, List<int> result)
        {
            if (root==null){
                return; 
            }

            InorderTraversalHelper(root.left, result);
            result.Add(root.val);
            InorderTraversalHelper(root.right, result);
        }

        /**
        * ? 94: Binary Tree Inorder Traversal 
        * ! Algorithm: Iterative (Use stack and while (true))
                1. When root is not null -> Push root to stack & root = root.left
                2. When root is null, (all lefts have been printed) -> print root & root = root.right
                3. When root is null & stack is empty; break out of while loop.
        * ! Notes: Combine conditions 2 & 3 in code. 
   
        **/
        public IList<int> InorderTraversalIterative(TreeNode root) 
        {
            var result = new List<int>();
            Stack<TreeNode> treestack = new Stack<TreeNode>();

            while(true)
            {
                // Condition #1 from algorithm above
                if (root!=null)
                {
                    treestack.Push(root);
                    root = root.left;
                }

                // Conditions #2 $ #3 from algorithm above
                else
                {
                    //Exit condition (#3) from while true (entire tree has been printed)
                    if (treestack.Count==0)
                    {
                        break;
                    }
                    
                    // Condition #2 from algorithm above
                    root = treestack.Pop();
                    result.Add(root.val);
                    root = root.right;

                }
            }
            return result;
        }

    
        /**
        * ? 100: Same Tree
        * ! Algorithm: 
            1. p.val == q.val && leftsubtrees are same && right subtrees are same == Same Trees
        * ! Notes: 
            1. If you return p.val == q.val separately, helper function will be needed. 
               The below return statement avoids the need of a helper function.
        **/
        public bool IsSameTree(TreeNode p, TreeNode q) 
        {
            if (p == null || q == null)
                return false;

            if (p == null && q == null)
                return true;

            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        /**
        * ? 572: Subtree of Another Tree
        * ! Algorithm: 
            1. Tree (t) can start either at s or at s.left or a s.right
            2. Tree (t) can also start at s.left.left; s.left.right; s.right.left; s.right.right
            3. Hence #2 makes a recursive call to #1  (condition #2 and #3 of the return statement).
            4. At every node on the first tree, check IsSameTree (condition #1 of the return statement).
        **/
        public bool IsSubtree(TreeNode s, TreeNode t) 
        {
            if (s == null || t == null)
                return false;
            
            return IsSameTree(s,t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);

        }


    }
}