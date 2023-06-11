using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CourseraGraderNetCore3
{
        
    public class LearnerProgram{

    public static int[] Merge(int[] A, int[] B){    
        if (A == null && B == null)
        {
            return null;
        }
        else if (A == null)
        {
            return B;
        }
        else if (B == null)
        {
            return A;
        }
        
        int[] mergedArray = new int[A.Length + B.Length];
        Array.Copy(A, mergedArray, A.Length);
        Array.Copy(B, 0, mergedArray, A.Length, B.Length);
        return mergedArray;

    }

   
    public static int SumDiagonal(int[,] A){

         if (A == null)
        {
            return -6666;
        }
        
        int rows = A.GetLength(0);
        int columns = A.GetLength(1);
        
        if (rows != columns)
        {
            return -5555;
        }
        
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            sum += A[i, i];
        }
        
        return sum;
    }

    
        public static Queue<int> StackToQueue(Stack<int> S)
        { 
            if (S == null)
        {
            return null;
        }
        
        Queue<int> queue = new Queue<int>(S);
        return queue;
        }

    
        public static int DictionaryCount(Dictionary<int, string> myDictionary)
        {
        
            if (myDictionary == null)
        {
            return -1;
        }

        return myDictionary.Count;
        }

    
        public static int MaxJArr(int [][] JArr)
        {
            if (JArr == null)
        {
            return -5555;
        }

        int maxNumber = int.MinValue;
        foreach (int[] subArray in JArr)
        {
            foreach (int num in subArray)
            {
                if (num > maxNumber)
                {
                    maxNumber = num;
                }
            }
        }

        return maxNumber;
        } 

  
        public static int CheckSortedDic(SortedDictionary<int, string> MySdict, string Val)
        {
           if (MySdict == null || MySdict.Count == 0)
        {
            return 0;
        }

        int count = 0;
        foreach (string value in MySdict.Values)
        {
            if (value == Val)
            {
                count++;
            }
        }

        return count;
        }
       
        public static string ListToString(List<string> list)
        {
           if (list == null || list.Count == 0)
        {
            return string.Empty;
        }

        return string.Join(" ", list);
    }
        
  }
}
