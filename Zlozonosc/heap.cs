using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zlozonosc
{
    class BinaryHeap
    {

        /// <summary>
        /// A binary heap implementation used to sort an integer array.
        /// 
        /// 1. The Max-Heapify and Min-Heapify methods maintain the heap properties.
        ///     
        /// 2. The Build-Heap methods produce the heap from an unordered array.
        /// 

        private int heapSize;

        public BinaryHeap()
        {
            heapSize = 0;
        }


        private int ParentIndex(int currentIndex)
        {
            return currentIndex / 2;
        }

        private int LeftIndex(int currentIndex)
        {
            return currentIndex * 2;
        }

        private int RightIndex(int currentIndex)
        {
            return currentIndex * 2 + 1;
        }


        // Building the heap
        #region
        public int[] BuildMaxHeap(int[] A)
        {
            heapSize = A.Length - 1;

            for (int i = A.Length / 2; i >= 0; i--)
            {
                MaxHeapify(A, i);
            }

            return A;
        }
        public int[] BuildMinHeap(int[] A)
        {
            heapSize = A.Length - 1;
            for (int i = A.Length / 2; i >= 0; i--)
            {
                MinHeapify(A, i);
            }

            return A;
        }
        #endregion

        // Maintaining heap properties
        //      MaxHeapify: Ensure that parents are larger than children
        //      MinHeapify: Ensure that children are larger than parents
        #region
        public void MaxHeapify(int[] A, int i)
        {

            int leftIndex = LeftIndex(i);
            int rightIndex = RightIndex(i);

            int largestIndex = 0;

            // Check to see which node in the tree subset has the largest value
            if (leftIndex <= heapSize && A[leftIndex] > A[i])
            {
                largestIndex = leftIndex;
            }
            else
            {
                largestIndex = i;
            }
            if (rightIndex <= heapSize && A[rightIndex] > A[largestIndex])
            {
                largestIndex = rightIndex;
            }

            // Do not make any switches if the largest node is the parent
            if (largestIndex != i)
            {
                int temp = A[largestIndex];
                A[largestIndex] = A[i];
                A[i] = temp;
                MaxHeapify(A, largestIndex);
            }

        }
        public void MinHeapify(int[] A, int i)
        {

            int leftIndex = LeftIndex(i);
            int rightIndex = RightIndex(i);
            int smallest;

            if (leftIndex <= heapSize && A[leftIndex] < A[i])
            {
                smallest = leftIndex;
            }
            else
            {
                smallest = i;
            }

            if (rightIndex <= heapSize && A[rightIndex] < A[smallest])
            {
                smallest = rightIndex;
            }

            if (smallest != i)
            {
                int temp = A[i];
                A[i] = A[smallest];
                A[smallest] = temp;
                MinHeapify(A, smallest);
            }

        }
        #endregion

        #region
        public int[] AscendingHeapSort(int[] A)
        {

            // Ensure all parents are greater than their children
            BuildMaxHeap(A);

            for (int i = A.Length - 1; i >= 0; i--)
            {
                int temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                heapSize--;
                MaxHeapify(A, 0);
            }

            return A;

        }

        public int[] DescendingHeapSort(int[] A)
        {

            // Ensure all parents are less than their children
            BuildMinHeap(A);

            for (int i = A.Length - 1; i >= 0; i--)
            {
                int temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                heapSize--;
                MinHeapify(A, 0);
            }

            return A;
        }
        #endregion





    }
}
