using System;

namespace LeetCode.Logic
{
    public class MatrixProblems
    {   
        /**
	    *! ALGORITHM
	        STEP 1: loop over all the cells in the board 
	        STEP 2: if the cells character is equal to the first letter in word and dfs call is true
				-> return true
	        STEP 3: the word was never found return false
        **/
        public bool Exist(char[][] board, string word) 
        {
            for(int i=0; i<board.Length;i++)
            {
                for(int j=0; j<board[i].Length; j++)
                {
                    if(board[i][j]==word[0] && ExistHelper(board, i, j, 0, word))
                        return true;
                }
            }
            return false;
        }

        /**
        *? 79. Word Search
        *! Algorithm
            BASE CASE: if index equals the words length
                   -> return true
            BASE CASE: if the row is out of the grid, the col is out of the grid, 
				   or the character at row,col does not equal the character in word at index
                    -> return false
        
            STEP 1: store the current char
            STEP 2: set the current char to ""
            STEP 3: call function in all four valid directions
            STEP 4: set the current char back
            STEP 5: return OR of all four calls
        **/
        public bool ExistHelper(char[][] board, int row, int col, int index, string word)
        {
            if(index == word.Length)
                return true;
            
            if(row < 0 || row >= board.Length || col < 0 || col >= board[row].Length || board[row][col] != word[index])
            {
                return false;
            }

            char current = board[row][col];
            board[row][col] = ' ';

            bool result = ExistHelper(board, row+1, col, index+1, word) 
            || ExistHelper(board, row, col+1, index+1, word) 
            || ExistHelper(board, row-1, col, index+1, word)
            || ExistHelper(board, row, col-1, index+1, word);

            board[row][col]= current;
            return result;
        }
    }
}