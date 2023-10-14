using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SelectionSort : ISortingAlgorithm
    {
        

        public void Sort(int[] A)
        {
            //TODO #1: Implement SelectionSort
            int n = A.Length;
            for (int pivot = 0; pivot < n - 1; pivot++)
            {
                for (int i = pivot + 1; i < n; i++)
                {
                    if (A[pivot] > A[i])
                        Utils.Swap(A, pivot, i);
                }
            }
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Sort()");
            Sort(A);
            if (!Utils.IsOrdered(A))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
