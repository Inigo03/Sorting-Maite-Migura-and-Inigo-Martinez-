using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class MergeSort : ISortingAlgorithm
    {
        public int[] Partition(int[] A, int startIndex, int endIndex)
        {
            //TODO #1: return a new array with all elements in A from index startIndex to endIndex (both included): A[startIndex..endIndex]
            int partitionLength = endIndex - startIndex + 1;
            int[] partition = new int[partitionLength];
            for (int i = 0; i < partitionLength; i++)
            {
                partition[i] = A[startIndex + i];
            }
            return partition;
        }

        public void MergePartitions(int[] A, int[] leftPartition, int[] rightPartition)
        {
            //TODO #2: Merge in A the two partitions sorting them
            int posLeft = 0;
            int posRight = 0;
            int i = 0;

            while (posLeft < leftPartition.Length || posRight < rightPartition.Length)
            {
                if (posLeft < leftPartition.Length && (posRight >= rightPartition.Length || leftPartition[posLeft] <= rightPartition[posRight]))
                {
                    A[i] = leftPartition[posLeft];
                    posLeft++;
                }
                else
                {
                    A[i] = rightPartition[posRight];
                    posRight++;
                }
                i++;
            }
        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
            if (A.Length != 1)
            {
                int mid = A.Length / 2;
                int[] leftPartition = Partition(A, 0, mid - 1);
                int[] rightPartition = Partition(A, mid, A.Length - 1);
                Sort(leftPartition);
                Sort(rightPartition);
                MergePartitions(A, leftPartition, rightPartition);
            }
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 3), 0, 3))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            if (!Utils.IsPartitionCorrect(A, Partition(A, 1, 1), 1, 1))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            Console.WriteLine("1.2. Checking MergePartitions()");
            int[] leftPartition = new int[3] { 1, 4, 6 };
            int[] rightPartition = new int[3] { 2, 3, 7 };
            int[] merged = new int[6] { 1, 4, 6, 2, 3, 7 };
            MergePartitions(merged, leftPartition, rightPartition);
            if (!Utils.IsOrdered(merged))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
