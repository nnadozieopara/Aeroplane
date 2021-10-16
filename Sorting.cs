//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MathematicsLib
//{
//    public static class Sorting
//    {
//        public static double[] InsertionSort(double[] array)
//        {
//            int length = array.Length;
//            for (int i = 1; i < length; i++)
//            {
//                int j = i;
//                do
//                {
//                    if (array[j] < array[j - 1])
//                    {
//                        double temp = array[j - 1];
//                        array[j - 1] = array[j];
//                        array[j] = temp;   
//                    }
//                    j--;
//                } while (j>0);      
//            }
//            return array;
//        }

//        public class MaxHeap<T>
//        {
//            private T[] heap;
//            private int count;
//            public MaxHeap(int heapSize)
//            {
//                heap = new T[heapSize];
//                count = 0;
//            }

//           public int Count
//            {
//                get { return count; }
//            }

//            public bool InHeap(T value)
//            {
//                int length = heap.Length;
//                for (int i = 0; i < length; i++)
//                {
//                    if (Equals(value, heap[i])) return true;
//                }
//                return false;
//            }

//            public void HeapifyBottom(int index)
//            {
//                int parent = (index - 1) / 2;
//                if (index < 0) return;
//                if (Comparer(heap[parent],heap[index])>0)
//                {

//                }
//            }
//        }
//    }
//}
